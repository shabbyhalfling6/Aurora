using UnityEngine;
using System.Collections;

public class EnemyLaser : MonoBehaviour {

    Transform myTransform;

    int moveSpeed = 600;
    float lifeSpan = 4.5f;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        Vector3 currentRot = myTransform.rotation.eulerAngles;
        myTransform.rotation = Quaternion.Euler(currentRot);
        this.GetComponent<Rigidbody>().AddForce(myTransform.forward * moveSpeed);
        Destroy(this.gameObject, lifeSpan);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
