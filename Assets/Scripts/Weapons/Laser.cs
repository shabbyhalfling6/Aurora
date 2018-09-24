using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    public int playerNum = 1;

    private Transform myTransform;

    private int moveSpeed = 2000;

    //Determains how long the projectie will stay alive
    private float lifeSpan = 1.0f;

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
    
    //changes the playernum
    public void SetPlayerNum(int number)
    {
        playerNum = number;
    }
}
