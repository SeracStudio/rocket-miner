using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float size;
    private float damage;
    private float shootSpeed;
    private bool playerShoot;

    public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setBasics(float shootSpeedA, float damageA, float sizeA, bool playerShootA )
    {
        shootSpeed = shootSpeedA;
        damage = damageA;
        size = sizeA;
        playerShoot = playerShootA;
    }

    public Vector2 dirCalculate(Vector3 pos)
    {
        var mousepos = Input.mousePosition;
        mousepos.z = 16;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousepos).normalized;

        return mousePosition;
    }

    public void Shoot(Vector3 pos, Vector2 dirA)
    {
        Bullet aux=Instantiate(bullet, pos, Quaternion.identity);
        //aux.dir = dirCalculate(pos);
        aux.dir = dirA;
        aux.shootSpeed=shootSpeed;
        aux.damage = damage;
        aux.playerShoot = playerShoot;
        aux.transform.localScale = new Vector3(size, size, size);
    }
}
