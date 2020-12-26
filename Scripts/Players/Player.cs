using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StatsController stats;
    public Rigidbody rigidBody;

    private Vector2 direction;
    private float dirX;
    private float dirY;
    private Vector2 lastDirection;

    public bool dash=false;

    private float slownessTime = 0;
    private float slownessCd;
    private bool slowness = false;
    private float slownessF = 1;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        stats = this.GetComponent<StatsController>();       
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Inputs();
        Rotation();
        checkSlowness();
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
            }
        }
    }


    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Attacked(float amount) { 
            
    }

    public virtual void Poisoned(float amount, float duration)
    {

    }

    public virtual void Slowness(float amount, float duration)
    {
        slownessF = 2;
        slownessCd = duration;
        slowness = true;
    }

    private void Rotation()
    {
        Vector3 mouse = Vector3.RotateTowards(transform.forward, getMouse(), Time.deltaTime * 10, 0.0f);
        mouse.y = 0;
        transform.rotation = Quaternion.LookRotation(mouse);
    }

    private Vector3 getMouse()
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

    private void Move()
    {
        if (!dash)
        {
            rigidBody.velocity = new Vector3(direction.x * (stats.GetStat(Stat.MOV_SPEED)/slownessF), 0, direction.y * (stats.GetStat(Stat.MOV_SPEED)/slownessF));
        }
    }

    void Inputs()
    {
        dirX = Input.GetAxisRaw("Vertical");
        dirY = Input.GetAxisRaw("Horizontal");
        direction = new Vector2(dirY, dirX);
        if(direction.x!=0.0f || direction.y != 0.0f)
        {
            lastDirection = direction;
        }
    }

    public Vector2 getLookingDirection()
    {
        return lastDirection;
    }
}
