using UnityEngine;
using System.Collections;

public class DualFireLaser : Weapon {

    private float fireRate = 0.1f;
    private float fireTime = 1.0f;

    public GameObject projectile;

    public GameObject[] muzzle;

    //Handles the weapon effects
    public override void fireWeapon()
    {
        fireTime += Time.deltaTime;

        if (fireTime >= fireRate)
        {
            audioController.playSound(audioController.SFX, audioController.playerShot, 1.0f);

            for(int i = 0; i < muzzle.Length; i++)
            {
                Instantiate(projectile, muzzle[i].transform.position, muzzle[i].transform.rotation);
            }

            fireTime = 0;
        }
    }
}
