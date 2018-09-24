using UnityEngine;
using System.Collections;

public class MiniBWeapon3 : MonoBehaviour {
    private Transform myTransform;
    private Quaternion currentRot;

    private float _Angle = 85.0f;
    private float _Period = 0.5f;

    private float _Time;

    public GameObject[] muzzles;
    private float fireRate = 0.1f;
    private float fireTime = 0.0f;

    public GameObject enemyLazer;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
	}

    // Update is called once per frame
    void Update()
    {
        Sway();
        FireWeapon();
    }

    //Rotates the object
    void Sway()
    {
        _Time = _Time + Time.deltaTime;
        float phase = Mathf.Sin(_Time / _Period);
        myTransform.localRotation = Quaternion.Euler(new Vector3(0, (phase * _Angle), 0));
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
