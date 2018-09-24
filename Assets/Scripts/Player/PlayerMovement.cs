using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public int playerNumb = 1;

    private GameController gameController;

    //Hold the wall values localy
    private float xBoarder;
    private float yBoarder;

    //Holds movement values
    private Transform myTransform;
    private int moveSpeed = 20;
    private int health = 150;
	private int TotalHealth = 150;
	public Slider healthBarSlider;

    //Hold strings for the controller
    private string horizontal;
    private string vertical;    

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
        SetStrings();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.addPlayer(this);
        int test = ShipSelection.P1Ship;
        print(test);

        int test2 = ShipSelection.P2Ship;
        print(test2);
    }
	
	// Update is called once per frame
	void Update () {
        SetStrings();
        Movement();
        SetWalls();

	}

    //Sets the wall limmits of the player
    private void SetWalls()
    {
        xBoarder = gameController.HoriWall;
        yBoarder = gameController.VertWall;
    }

    //Sets strings depending on the player number
    public void SetStrings()
    {
        //Base string { = "P" + playerNumb + "_"}
        horizontal = "P" + playerNumb + "_Horizontal";
        vertical = "P" + playerNumb + "_Vertical";
    }

    //Handles movement
    private void Movement()
    {
        //Place holder for postion edits
        Vector3 currentPos = myTransform.position;

        // JOYSTICK
        //Moves the player alongg the X Axis
        if (Input.GetAxis(horizontal) != 0)
        {
            currentPos.x += moveSpeed * Time.deltaTime * Input.GetAxis(horizontal);
        }

        //moves the player along the Y axis
        if (Input.GetAxis(vertical) != 0)
        {
            currentPos.z += moveSpeed * Time.deltaTime * Input.GetAxis(vertical);
        }

        //KEYBOARD
        //keyboard testing
        if (Input.GetKey("a"))
        {
            currentPos.x -= moveSpeed * Time.deltaTime;
        }

        //keyboard testing
        if (Input.GetKey("d"))
        {
            currentPos.x += moveSpeed * Time.deltaTime;
        }

        //keyboard testing
        if (Input.GetKey("w"))
        {
            currentPos.z += moveSpeed * Time.deltaTime;
        }

        //keyboard testing
        if (Input.GetKey("s"))
        {
            currentPos.z -= moveSpeed * Time.deltaTime;
        }

        //limmits player movement to the boarder
        //Top Limmit
        if (currentPos.z >= yBoarder)
        {
            currentPos.z = yBoarder;
        }

        //Bottom Limmit
        if(currentPos.z <= -yBoarder)
        {
            currentPos.z = -yBoarder;
        }

        //Left Limmit
        if (currentPos.x <= -xBoarder)
        {
            currentPos.x = -xBoarder;
        }

        //Left Limmit
        if (currentPos.x >= xBoarder)
        {
            currentPos.x = xBoarder;
        }

        //sets the new postion
        myTransform.position = currentPos;
    }

    //Handles collitions
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag=="EnemyLaser")
        {
            health -= 10;

            if (health <= 0)
            {
                Destroy(this.gameObject);
                gameController.numPlayers--;
				healthBarSlider.value =0f;
            }
            Destroy(otherObject.gameObject);

        }
        healthBarSlider.value = ((float)health / (float)TotalHealth);
    }
}
