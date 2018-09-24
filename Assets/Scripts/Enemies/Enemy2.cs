using UnityEngine;
using System.Collections;

public class Enemy2 : Enemy {

    int unitHealth = 40;
    int unitSpeed = 2;
    float fireTime = 10;
    float fireRate = 1.5f;

    public override void SetUnitValues()
    {
        health = unitHealth;
        moveSpeed = unitSpeed;

        track = true;
    }

    //Creates and fires enemy bullets in the direction that the enemy is facing
    public override void FireWeapon()
    {
        if (fireTime >= fireRate)
        {
            fireTime = 0;
            for (int i = 0; i < muzzle.Length; i++)
            {
                Instantiate(enemyLaser, muzzle[i].transform.position, muzzle[i].transform.rotation);
            }
        }
        fireTime += Time.deltaTime;
    }
}
