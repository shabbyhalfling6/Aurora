using UnityEngine;
using System.Collections;

public class MiniBWeapoon2 : MonoBehaviour {

    public GameObject[] muzzles;
    private float fireRate = 1.0f;
    private float fireTime = 0.0f;

    public GameObject enemyLazer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        FireWeapon();
	}

    //Fires the weapon
    void FireWeapon()
    {
        if (fireTime >= fireRate)
        {
            for (int i = 0; i < muzzles.Length; i++)
            {
                Instantiate(enemyLazer, muzzles[i].transform.position, muzzles[i].transform.rotation);
            }

            fireTime = 0.0f;
        }
        fireTime += Time.deltaTime;
    }
}
