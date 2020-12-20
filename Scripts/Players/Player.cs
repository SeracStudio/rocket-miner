using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 6f;
    public float cdOf;
    public float cdDef;

    private Vector2 direction;
    private float dirX;
    private float dirY;
    private Vector2 lastDirection;

    public bool dash=false;

    public Rigidbody rigidBody;

    // Start is called before the first frame update
    public virtual void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
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
            rigidBody.velocity = new Vector3(direction.x * movementSpeed, 0, direction.y * movementSpeed);
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
