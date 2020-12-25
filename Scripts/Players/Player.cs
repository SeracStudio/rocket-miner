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
    }


    public virtual void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!dash)
        {
            rigidBody.velocity = new Vector3(direction.x * stats.GetStat(Stat.MOV_SPEED), 0, direction.y * stats.GetStat(Stat.MOV_SPEED));
        }
    }

    void Inputs()
    {
        dirX = Input.GetAxisRaw("Vertical");
        dirY = Input.GetAxisRaw("Horizontal");
        //Debug.Log(dirX + " " + dirY);
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
