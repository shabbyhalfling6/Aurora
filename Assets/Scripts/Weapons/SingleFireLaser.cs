using UnityEngine;
using System.Collections;
using System;

public class SingleFireLaser : Weapon {

    private float fireRate = 0.1f;
    private float fireTime = 1.0f;

    public GameObject projectile;

    //Handles the weapon effects
    public override void fireWeapon()
    {
        fireTime += Time.deltaTime;

        if(fireTime >= fireRate)
        {
            audioController.playSound(audioController.SFX,audioController.playerShot,1.0f);
            GameObject playerLaser = Instantiate(projectile,myTransform.position,myTransform.rotation) as GameObject;
            playerLaser.GetComponent<Laser>().SetPlayerNum(playerNumb);
            fireTime = 0;
        }
    }
}
