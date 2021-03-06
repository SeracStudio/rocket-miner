﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : NetworkBehaviour
{

    public Vector3 dir;
    private Rigidbody rigidBody;
    public float shootSpeed;

    public float damage;
    public float playerShoot;
    public bool rain = false;

    public List<BulletEffect> effects;

    private Girl girl;
    private Robot robot;
    private bool tele=false;
    private bool dontDestroy = false;

    public bool magnetGun = false;
    private float magnetGunTime = 0;
    private float magnetGunCd = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        girl = FindObjectOfType<Girl>();
        robot = FindObjectOfType<Robot>();
        foreach (BulletEffect item in effects)
        {
            if (item.effect == BEffects.TELE)
            {
                tele = true;
                break;
            }
        }
        magnetGun = girl.magnetGun;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!isOnMaster) return;

        if (other.tag == "Wall")
        {
            PhotonNetwork.Destroy(gameObject);
        }

        if (other.tag == "Floor")
        {
            PhotonNetwork.Destroy(gameObject);
        }

        if (other.tag =="Enemy" && playerShoot==0)
        {         
            if (other.gameObject.GetComponent<StatsController>().GetStat(Stat.ENEMY_SHIELD) == 1)
            {
                PhotonNetwork.Destroy(gameObject);
                return;
            }

            other.GetComponent<MaterialFlickerer>().TriggerRPC("FlickerMat", RpcTarget.AllBuffered);

            other.gameObject.GetComponent<StatsController>().SetStat(Stat.HEALTH, OperationFunc.FloatSolve(Operation.SUBTRACT,other.gameObject.GetComponent<StatsController>().GetStat(Stat.HEALTH), damage));

            if (other.gameObject.GetComponent<StatsController>().GetStat(Stat.HEALTH) <= 0)
            {
                if(other.TryGetComponent(out Slime slime))
                {
                    other.GetComponent<Slime>().NextSlime();
                    if(other.GetComponent<Slime>().level == 3)
                    {
                        if(Random.Range(0, 7) == 0)
                        {
                            PhotonNetwork.Instantiate("CornItem", new Vector3(transform.position.x, 1, transform.position.z), Quaternion.identity);
                        }
                    }
                }

                if (other.GetComponent<Enemy>().boss)
                {
                    foreach (GameObject gObj in GameObject.FindGameObjectsWithTag("Enemy"))
                    {
                        PhotonNetwork.Destroy(gObj);
                        MapController.RUNNING.EnemyEliminated();
                    }

                    MapController.RUNNING.mapRenderer.SpawnStairsAfterDelay(2);
                }

                if(other.name == "Nomed(Clone)")
                {
                    DisconnectManager.INSTANCE.GetComponent<PhotonView>().RPC("VictoryEndGame", RpcTarget.AllBuffered);
                }

                MapController.RUNNING.EnemyEliminated();
                PhotonNetwork.Instantiate("Effects/EnemyDeathEffect", new Vector3(other.transform.position.x, 0, other.transform.position.z), Quaternion.identity);
                PhotonNetwork.Destroy(other.gameObject);          
            }
            PhotonNetwork.Destroy(this.gameObject);
        }

        if((other.tag=="GIRL") && playerShoot == 1)
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
                        /*
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
                        */
                }
            }
            TriggerRPC("Destroy");
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
        checkMagnetGun();
    }

    private void checkMagnetGun()
    {
        if (playerShoot == 1) return;

        if (magnetGun)
        {
            magnetGunTime += Time.deltaTime;
            if (magnetGunTime > magnetGunCd)
            {
                Vector3 dirToGirl = girl.transform.position - transform.position;
                dirToGirl.Normalize();

                transform.forward = dirToGirl;
                dir.x = dirToGirl.x;
                dir.z = dirToGirl.z;
                magnetGun = false;
            }
        }
    }
}
