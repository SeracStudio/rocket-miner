using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Health health;
    public MovementSpeed movementSpeed;
    public CdOf cdOf;
    public CdDef cdDef;

    public ShootsPerSecond shootsPerSecond;
    public ShootDamage shootDamage;
    public NDashDefault nDashDefault;

    public BulletSize bulletSize;
    public BulletSpeed bulletSpeed;

    public bool isPlayer;

    void Start() {
        health = new Health();
        movementSpeed = new MovementSpeed();
        cdOf = new CdOf();
        cdDef = new CdDef();
        shootsPerSecond = new ShootsPerSecond();
        shootDamage=new ShootDamage();
        nDashDefault=new NDashDefault();
        bulletSize=new BulletSize();
        bulletSpeed=new BulletSpeed();
}

    //Init
    public void initPlayerStats()
    {
        setMovementSpeed(6);
        setIsPlayer(true);
    }

    public void initGirlStats()
    {
        setShootsPerSecond(3);
        setShootDamage(2);
        setHealth(100);
        setNDashDefault(2);
        setCdOf(1f / getShootsPerSecond());
        setCdDef(0.75f);
        setBulletSize(1);
        setBulletSpeed(15);       
    }

    public void initRobotStats()
    {
        setCdOf(2);
        setCdDef(1);
    }

    //Funciones


    //Getters/Setters/Change
    //Health
    public int getHealth()
    {
        return health.get();
    }

    public void setHealth(int amount)
    {
        health.set(amount);
    }

    public void changeHealth(int amount)
    {
        health.change(amount);
    }

    //MovementSpeed
    public float getMovementSpeed()
    {
        return movementSpeed.get();
    }

    public void setMovementSpeed(float amount)
    {
        movementSpeed.set(amount);
    }

    public void changeMovementSpeed(float amount)
    {
        movementSpeed.change(amount);
    }

    //CdOf
    public float getCdOf()
    {
        return cdOf.get();
    }

    public void setCdOf(float amount)
    {
        cdOf.set(amount);
    }

    public void changeCdOf(float amount)
    {
        cdOf.change(amount);
    }

    //CdDef
    public float getCdDef()
    {
        return cdDef.get();
    }

    public void setCdDef(float amount)
    {
        cdDef.set(amount);
    }

    public void changeCdDef(float amount)
    {
        cdDef.change(amount);
    }

    //ShootsPerSecond
    public int getShootsPerSecond()
    {
        return shootsPerSecond.get();
    }

    public void setShootsPerSecond(int amount)
    {
        shootsPerSecond.set(amount);
    }

    public void changeShootsPerSecond(int amount)
    {
        shootsPerSecond.change(amount);
    }

    //ShootDamage
    public int getShootDamage()
    {
        return shootDamage.get();
    }

    public void setShootDamage(int amount)
    {
        shootDamage.set(amount);
    }

    public void changeShootDamage(int amount)
    {
        shootDamage.change(amount);
    }

    //NDashDefault
    public int getNDashDefault()
    {
        return nDashDefault.get();
    }

    public void setNDashDefault(int amount)
    {
        nDashDefault.set(amount);
    }

    public void changeNDashDefault(int amount)
    {
        nDashDefault.change(amount);
    }

    //BulletSize
    public float getBulletSize()
    {
        return bulletSize.get();
    }

    public void setBulletSize(float amount)
    {
        bulletSize.set(amount);
    }

    public void changeBulletSize(float amount)
    {
        bulletSize.change(amount);
    }

    //BulletSpeed
    public float getBulletSpeed()
    {
        return bulletSpeed.get();
    }

    public void setBulletSpeed(float amount)
    {
        bulletSpeed.set(amount);
    }

    public void changeBulletSpeed(float amount)
    {
        bulletSpeed.change(amount);
    }

    //isPlayer
    public bool getIsPlayer()
    {
        return isPlayer;
    }

    public void setIsPlayer(bool amount)
    {
        isPlayer = amount;
    }
}
