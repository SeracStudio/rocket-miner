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
    public bool rain = false;

    public List<BulletEffect> effects;

    private Girl girl;
    private bool tele=false;
    private bool dontDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        girl = FindObjectOfType<Girl>();
        foreach (BulletEffect item in effects)
        {
            if (item.effect == BEffects.TELE)
            {
                tele = true;
                break;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag=="Floor")
        {
            Destroy(this.gameObject);
        }

        if(other.tag =="Enemy" && playerShoot==0 && other.gameObject.GetComponent<StatsController>().GetStat(Stat.ENEMY_SHIELD)==0)
        {
            other.gameObject.GetComponent<StatsController>().SetStat(Stat.HEALTH, OperationFunc.FloatSolve(Operation.SUBTRACT,other.gameObject.GetComponent<StatsController>().GetStat(Stat.HEALTH), damage));
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
                        other.gameObject.GetComponent<Player>().Poisoned(damage);
                        break;
                    case (BEffects.SLOWNESS):
                        other.gameObject.GetComponent<Player>().Slowness(damage, effect.durationTime);
                        break;
                    case (BEffects.SPECIAL):
                        if (other.tag == "ROBOT")
                        {
                            if (!other.GetComponent<Robot>().shield)
                            {
                                dontDestroy = true;
                            }
                        }
                        else
                        {
                            other.gameObject.GetComponent<Player>().Attacked(damage);
                        }
                        break;
                }
            }
            if (!dontDestroy)
            {
                Destroy(this.gameObject);
            }         
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!tele)
        {
            if (rain)
            {
                rigidBody.velocity = new Vector3(dir.x * shootSpeed, -1*shootSpeed, dir.z * shootSpeed);
            }
            else
            {
                rigidBody.velocity = new Vector3(dir.x * shootSpeed, 0, dir.z * shootSpeed);
            }        
        }
        else
        {
            Vector3 dirT = (girl.transform.position - this.transform.position).normalized;
            rigidBody.velocity = new Vector3(dirT.x * shootSpeed, 0, dirT.z * shootSpeed);
        }

    }
}
