using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 dir;
    private Rigidbody rigidBody;
    public float shootSpeed;

    public float damage;
    public float playerShoot;

    public List<BulletEffect> effects;

    private Girl girl;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if(other.tag =="Enemy" && playerShoot==0 && other.gameObject.GetComponent<StatsController>().GetStat(Stat.ENEMY_SHIELD)==0)
        {
            //Reducir vida enemigo 
            if (other.gameObject.GetComponent<StatsController>().GetStat(Stat.HEALTH) <= 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(this.gameObject);
        }

        if((other.tag=="Attack" || other.tag=="ROBOT") && playerShoot == 1)
        {
            foreach (BulletEffect effect in effects)
            {
                switch (effect.effect)
                {
                    case (BEffects.NORMAL):
                        other.gameObject.GetComponent<Player>().Attacked(damage);
                        break;
                    case (BEffects.POISON):
                        other.gameObject.GetComponent<Player>().Poisoned(damage, effect.durationTime);
                        break;
                    case (BEffects.SLOWNESS):
                        other.gameObject.GetComponent<Player>().Slowness(damage, effect.durationTime);
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector3(dir.x * shootSpeed, 0, dir.z * shootSpeed);
    }
}
