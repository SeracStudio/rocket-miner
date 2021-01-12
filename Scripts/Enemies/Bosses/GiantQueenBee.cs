using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantQueenBee : MonoBehaviour
{
    private Enemy enemy;
    public Enemy colmena;

    private Girl girl;
    private Robot robot;

    private bool check = true;

    public float aleteoTime = 0;
    private float aleteoCd = 10f;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        girl = FindObjectOfType<Girl>();
        robot = FindObjectOfType<Robot>();
        PhotonNetwork.Instantiate("Enemies/EnemySet/" + colmena.name, new Vector3(-10, 0f, 3), Quaternion.identity);
        PhotonNetwork.Instantiate("Enemies/EnemySet/" + colmena.name, new Vector3(10, 0f, 3), Quaternion.identity);
        MapController.RUNNING.enemiesLeft += 2;
    }

    // Update is called once per frame
    void Update()
    {
        checkColmenas();
        checkAleteo();
    }

    private void checkAleteo()
    {
        aleteoTime += Time.deltaTime;
        if (aleteoTime >= aleteoCd)
        {
            aleteoTime = 0;
            if (!robot.shield)
            {
                Aleteo();
            }
        }
    }

    private void checkColmenas()
    {
        if (check)
        {
            Enemy[] colmenas = FindObjectsOfType<Enemy>();
            int aux = 0;
            for (int i = 0; i < colmenas.Length; i++)
            {
                if (colmenas[i].colmena)
                {
                    aux++;
                }
            }
            if (aux == 0)
            {
                enemy.NoColmena = true;
                check = false;
            }
        }
    }

    private void Aleteo()
    {
        Vector3 girlDirection = girl.transform.position -transform.position;//-girl.rigidBody.velocity;
        Vector3 robotDirection = robot.transform.position - transform.position;//-robot.rigidBody.velocity;
        girl.knock = true;
        girl.rigidBody.velocity = Vector3.zero;
        robot.knock = true;
        robot.rigidBody.velocity = Vector3.zero;
        girl.rigidBody.AddForce(girlDirection.normalized * 1000);
        robot.rigidBody.AddForce(robotDirection.normalized * 1000);
    }
}
