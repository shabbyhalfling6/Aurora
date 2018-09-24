using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour 
{
	//public Slider healthBarSlider;
	protected HighScore highScore;
	public int points;

    //Audio manager for sounds and game controller
    public AudioController audioController;
    private GameController gameController;

    //Enemy basic value
    public int health;
    public float moveSpeed;
    public bool track = false;

    //Hold the transform
    Transform myTransform;

    //Player Tracking Values
    private GameObject[] players;
    private GameObject closestPlayer;

    public float rotationSpeed = 0.1f;
    private float adjRotationSpeed;
    private Quaternion targetRotation;

    //Distnace that the object must be from the center to be destroyerd 
    private int vertBoarder = 20;
    private int vertBoarderMax = 80;
    private int horiBoarder = 30;


    //Holds the enemy projectile
    public GameObject enemyLaser;
    public GameObject[] muzzle;

    // Use this for initialization
    void Start()
    {
        myTransform = this.transform;
        SetUnitValues();
        players = GameObject.FindGameObjectsWithTag("Player");
		//highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<HighScore>();
        audioController = GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update () {
        MoveForward();
        
        if (myTransform.position.z <= gameController.VertWall)
        {
            FireWeapon();
        }
	}
    
    // Makes the enemy move forward at a constant speed
    void MoveForward()
    {
        if(track == true)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            LookAtPlayer();
        }
        Vector3 currentPos = myTransform.position;
        currentPos += transform.forward * moveSpeed * Time.deltaTime;
        myTransform.position = currentPos;
        CheckBoandry(currentPos);
    }

    //Handles what happen when the object is hit
    void OnTriggerEnter(Collider otherObject)
    {
//		if(otherObject.gameObject.tag=="Laser" && healthBarSlider.value>0)
//		{
//			healthBarSlider.value -=.01f; 
//			RemoveHealth(10);
//			Destroy(otherObject.gameObject);
//		}
		if(otherObject.gameObject.tag=="Laser" )
        {
            RemoveHealth(10);
            Destroy(otherObject.gameObject);
        }
    }

    //Makes the objectr lose health
    public void RemoveHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            gameController.totalScore += 10;
			//highScore.StoreScore(points);
            audioController.playSound(audioController.EXP,audioController.enemyDeath,0.2f);
        }
    }

    //determines wether or not the object is too far and delets it if so
    void CheckBoandry(Vector3 pos)
    {
        if (pos.z <= -vertBoarder || pos.z >= vertBoarderMax)
        {
            Destroy(this.gameObject);
        }
        if (pos.x <= -horiBoarder || pos.x >= horiBoarder)
        {
            Destroy(this.gameObject);
        }
    }

    //sets the basic values for the unit
    public abstract void SetUnitValues();

    //Creates and fires enemy bullets in the direction that the enemy is facing
    public abstract void FireWeapon();

    //Turns to face the closest player
    void LookAtPlayer()
    {
        FindClosestPlayer();
        if (closestPlayer != null)
        {
            if (closestPlayer.transform.position.z < myTransform.position.z)
            {
                targetRotation = Quaternion.LookRotation(closestPlayer.transform.position - myTransform.position);
                adjRotationSpeed = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, adjRotationSpeed);

            }
        }
        else
        {
            targetRotation = Quaternion.LookRotation(new Vector3(0,-100,0) - myTransform.position);
            adjRotationSpeed = Mathf.Min(rotationSpeed * Time.deltaTime, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, adjRotationSpeed);
        }
    }

    //Locates the closest player to the enemy
    private void FindClosestPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {

                if (i == 0)
                {
                    closestPlayer = players[0];
                }

                float playerDistnace = Vector3.Distance(myTransform.position, players[i].transform.position);
                float oldDistance = Vector3.Distance(myTransform.position, closestPlayer.transform.position);

                if (playerDistnace <= oldDistance)
                {
                    closestPlayer = players[i];
                }
            }
        }
    }

}
