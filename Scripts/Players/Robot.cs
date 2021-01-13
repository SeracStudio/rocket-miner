using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Player
{
    public bool shield = false;
    public float shieldTime = 0;
    private bool canUseShield = true;

    public float punchTime = 0;
    private bool canUsePunch = true;
    public bool punch = false;

    public Action OnShield;
    public Action<GameObject> OnEnemyPunched;

    public Animator anim;
    public GameObject shieldSphere;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!isMine) return;

        base.Update();

        InputsR();
        checkShield();
        checkPunch();
    }

    public override void FixedUpdate()
    {
        if (!shield)
        {
            base.FixedUpdate();
        }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }
    }

    private void InputsR()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canUseShield)
        {
            //Shield()
            shield = true;
            anim.SetBool("defense", true);
            TriggerRPC("Shield", RpcTarget.MasterClient);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //ReleaseShield();
            shield = false;
            anim.SetBool("defense", false);
            TriggerRPC("ReleaseShield", RpcTarget.MasterClient);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canUsePunch)
        {
            //Punch();
            TriggerRPC("Punch", RpcTarget.MasterClient);
        }
    }

    public override void Attacked(float amount)
    {
        base.Attacked(amount);
    }

    public override void Poisoned(float amount)
    {
        base.Poisoned(amount);
    }

    public override void Slowness(float amount, float duration)
    {
        base.Slowness(amount, duration);
    }

    [PunRPC]
    public void Shield()
    {
        TriggerRPC(nameof(SetActiveShield), RpcTarget.AllBuffered, true);
        shield = true;
        OnShield?.Invoke();
    }

    [PunRPC]
    public void SetActiveShield(bool state)
    {
        shieldSphere.SetActive(state);
    }

    [PunRPC]
    public void ReleaseShield()
    {
        TriggerRPC(nameof(SetActiveShield), RpcTarget.AllBuffered, false);
        shield = false;
        canUseShield = false;
        shieldTime = 0.01f;
    }

    [PunRPC]
    public void Punch()
    {
        punchTime = 0.01f;
        canUsePunch = false;
        punch = true;
        PunchOnEnemy();
    }

    private void PunchOnEnemy()
    {
        Enemy[] enemies;
        enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, this.transform.position) < 5)
            {
                enemies[i].Stunned();
                OnEnemyPunched?.Invoke(enemies[i].gameObject);
                break;
            }
        }
    }

    private void checkPunch()
    {
        if (punchTime > 0)
        {
            punchTime += Time.deltaTime;
            if (punchTime > stats.GetStat(Stat.OFFENSIVE_CD))
            {
                canUsePunch = true;
                punchTime = 0;
            }
            if (punchTime > 0.3)
            {
                punch = false;
            }
        }
    }

    private void checkShield()
    {
        if (shieldTime > 0)
        {
            shieldTime += Time.deltaTime;
            if (shieldTime > stats.GetStat(Stat.DEFENSIVE_CD))
            {
                canUseShield = true;
                shieldTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (!PlayerInstantiater.RUNNING.IsGirl()) return;
        if (!isOnMaster) return;

        if (!other.TryGetComponent(out Bullet bullet)) return;
        if (bullet.playerShoot == 0) return;
        /*
        if (!bullet.effects.Contains(new BulletEffect { effect = BEffects.SPECIAL }))
        {
            if (TryGetComponent(out ReflectingMirror reflector) && shield)
            {
                reflector.Effect(other.gameObject);
            }
            else
            {
                bullet.TriggerRPC("Destroy");
            }
        }
        else
        {
            if(shield)
                bullet.TriggerRPC("Destroy");
        }*/

        if (TryGetComponent(out ReflectingMirror reflector) && shield)
        {
            reflector.Effect(other.gameObject);
        }
        else
        {
            if (shield)
                bullet.TriggerRPC("Destroy");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (!PlayerInstantiater.RUNNING.IsGirl()) return;
        if (!isOnMaster) return;

        if (!other.TryGetComponent(out Bullet bullet)) return;
        if (bullet.playerShoot == 0) return;

        /*
        if (!bullet.effects.Contains(new BulletEffect { effect = BEffects.SPECIAL }))
        {
            if (TryGetComponent(out ReflectingMirror reflector) && shield)
            {
                reflector.Effect(other.gameObject);
            }
            else
            {
                bullet.TriggerRPC("Destroy");
            }
        }
        else
        {
            if (shield)
                bullet.TriggerRPC("Destroy");
        }*/
        if (TryGetComponent(out ReflectingMirror reflector) && shield)
        {
            reflector.Effect(other.gameObject);
        }
        else
        {
            if (shield)
                bullet.TriggerRPC("Destroy");
        }
    }

    public void OnShieldActionPhone()
    {
        shield = true;
        anim.SetBool("defense", true);
        TriggerRPC("Shield", RpcTarget.MasterClient);
    }

    public void OffShieldActionPhone()
    {
        shield = false;
        anim.SetBool("defense", false);
        TriggerRPC("ReleaseShield", RpcTarget.MasterClient);
    }

    public void PunchActionPhone()
    {
        TriggerRPC("Punch", RpcTarget.MasterClient);
    }
}
