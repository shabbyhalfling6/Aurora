using UnityEngine;
using System.Collections;

public class PlayerAiming : MonoBehaviour {

    public int playerNumb;
    private bool numbChecked = false;

    private Transform myTransform;

    //String variables
    private string mouseX;
    private string mouseY;

    //Aiming Values
    float aimingX;
    float aimingY;

    //Set strings
    private void setStrings()
    {
        if (numbChecked == false)
        {
            //Finds the player number from its parent
            playerNumb = gameObject.GetComponentInParent<PlayerMovement>().playerNumb;

            //Sets strong variables
            mouseX = "P" + playerNumb + "_MouseX";
            mouseY = "P" + playerNumb + "_MouseY";
            numbChecked = true;
        }
    }

    // Use this for initialization
    void Start () {
        //sets the players transform
        myTransform = this.transform;
    }

    // Update is called once per frame
    void Update () {
        //Sets player Numb
        setStrings();

        Quaternion currentAngle = myTransform.rotation;

        // Handles aiming of player
        if (Input.GetAxis(mouseX) != 0)
        {
            aimingX = -Input.GetAxis(mouseX);
        }
        else aimingX = 0;

        if (Input.GetAxis(mouseY) != 0)
        {
            aimingY = -Input.GetAxis(mouseY);
        }
        else aimingY = 0;
       
        //Culculates the desired angle of the Weapon Pivot
        float angle = (Mathf.Atan2(aimingX, aimingY) * Mathf.Rad2Deg);
        currentAngle = Quaternion.Euler(0, angle, 0);

        //Sets pivot angle
        myTransform.rotation = currentAngle;
    }
}
