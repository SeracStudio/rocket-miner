using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 dir;
    private Rigidbody rigidBody;
    public float shootSpeed;

    public float damage;
    public bool playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision");
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(dir.x * shootSpeed, 0, dir.y * shootSpeed);
    }
}
