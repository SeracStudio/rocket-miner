using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public StatsController stats;
    public Rigidbody rigidBody;

    private Vector2 direction;
    private float dirX;
    private float dirY;
    private Vector2 lastDirection;

    public bool dash = false;

    private float slownessTime = 0;
    private float slownessCd;
    private bool slowness = false;
    private float slownessF = 1;

    public bool inversed;

    public bool stunned = false;
    public float stunCd = 2f;
    public float stunTime = 0;

    public bool knock = false;
    private float knockTime = 0;
    private float knockCd = 1f;

    protected FloatingJoystick movementJoystick;
    protected FloatingJoystick spinJoystick;

    protected Vector3 mouse;

    // Start is called before the first frame update
    public virtual void Start()
    {
        movementJoystick = GameObject.Find("MovementJoystick").GetComponent<FloatingJoystick>();
        spinJoystick = GameObject.Find("DirJoystick").GetComponent<FloatingJoystick>();

        rigidBody = this.GetComponent<Rigidbody>();
        stats = this.GetComponent<StatsController>();
        stats.GetStat(Stat.MOV_SPEED);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Inputs();
        Rotation();
        checkSlowness();
        checkStunned();
        checkKnock();
    }

    private void checkKnock()
    {
        if (knock)
        {
            knockTime += Time.deltaTime;
            if (knockTime >= knockCd)
            {
                knockTime = 0;
                knock = false;
            }
        }
    }

    private void checkSlowness()
    {
        if (slowness)
        {
            slownessTime += Time.deltaTime;
            if (slownessTime > slownessCd)
            {
                slowness = false;
                slownessF = 1;
                slownessTime = 0;
            }
        }
    }

    private void checkStunned()
    {
        if (stunned)
        {
            stunTime += Time.deltaTime;
            if (stunTime >= stunCd)
            {
                stunTime = 0;
                stunned = false;
            }
        }
    }


    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Attacked(float amount)
    {

    }

    public virtual void Poisoned(float amount)
    {

    }

    public virtual void Slowness(float amount, float duration)
    {
        slownessF = 2;
        slownessCd = duration;
        slowness = true;
    }

    public virtual void Stunned(float amount, float duration)
    {
        if (!stunned)
        {
            stunCd = duration;
            stunned = true;
        }
    }

    private void Rotation()
    {
        if (!isMine) return;

        if (!Application.isMobilePlatform)
        {
            mouse = Vector3.RotateTowards(transform.forward, getMouse(), Time.deltaTime * 10, 0.0f);
            mouse.y = 0;
        }
        else
        {
            float dirX = spinJoystick.Horizontal;
            float dirZ = spinJoystick.Vertical;
            mouse = Vector3.RotateTowards(transform.forward, new Vector3(dirX, 0, dirZ), Time.deltaTime * 10, 0.0f);
            mouse.y = 0;
        }

        transform.rotation = Quaternion.LookRotation(mouse);
    }

    protected Vector3 getMouse()
    {
        Vector3 target = new Vector3(0, 0, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hit.collider.tag.Equals("Floor"))
            {
                target = hit.point - transform.position;
                return target.normalized;
            }
        }
        return new Vector3(0, 0, 0);
    }

    protected Vector3 getMouse2()
    {
        Vector3 target = new Vector3(0, 0, 0);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Default")))
        {
            if (hit.collider.tag.Equals("Floor"))
            {
                target = hit.point - transform.position;
                return hit.point;
            }
        }
        return new Vector3(0, 0, 0);
    }

    private void Move()
    {
        if (!dash && !stunned && !knock)
        {
            rigidBody.velocity = new Vector3(direction.x * (stats.GetStat(Stat.MOV_SPEED) / slownessF), 0, direction.y * (stats.GetStat(Stat.MOV_SPEED) / slownessF));
        }
        else if (stunned && !knock)
        {
            rigidBody.velocity = Vector3.zero;
        }
    }

    void Inputs()
    {
        if (!isMine) return;

        if (!Application.isMobilePlatform)
        {
            dirX = Input.GetAxisRaw("Vertical");
            dirY = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            dirX = movementJoystick.Vertical;
            dirY = movementJoystick.Horizontal;
        }


        if (inversed)
        {
            dirX = -dirX;
            dirY = -dirY;
        }

        direction = new Vector2(dirY, dirX);
        direction.Normalize();
        if (direction.x != 0.0f || direction.y != 0.0f)
        {
            lastDirection = direction;
        }
    }

    public Vector2 getLookingDirection()
    {
        return lastDirection;
    }

    [PunRPC]
    public void SetInversedMovement(bool state)
    {
        inversed = state;
    }
}
