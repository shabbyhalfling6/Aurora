using UnityEngine;
using System.Collections;

public abstract class SpecialWeapon : MonoBehaviour {

	public Transform myTransform;

	private string fire2;

    public GameObject player;

	private int playerNumb;

	// Use this for initialization
	void Start () {
		playerNumb = player.GetComponent<PlayerMovement>().playerNumb;
		myTransform = this.transform;
		fire2 = "P" + playerNumb + "_Fire2";
	}
	
	// Update is called once per frame
	void Update () {
        CheckInputs();
	}

	//Check for inputs
	private void CheckInputs()
	{
		if(Input.GetAxis(fire2) != 0)
        {
            Ability();
            //Special power
        }
	}

    //Produces the actual ability
    public abstract void Ability();
}
