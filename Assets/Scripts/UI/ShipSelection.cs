using UnityEngine;
using System.Collections;

public class ShipSelection : MonoBehaviour {
    public static int P1Ship = 1;
    public static int P2Ship = 1;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Sets the player 1st players ship type
    public void P1SetShipType(int ship)
    {
        P1Ship = ship;
    }

    //Sets the player 1st players ship type
    public void P2SetShipType(int ship)
    {
        P2Ship = ship;
    }

    public void PlayLevel()
    {
        Application.LoadLevel("InGame");
    }

    public void MoveToCustom()
    {
        Application.LoadLevel("CustomizationMenu");
    }
}
