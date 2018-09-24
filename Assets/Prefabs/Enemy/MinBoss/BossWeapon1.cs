using UnityEngine;
using System.Collections;

public class BossWeapon1 : MonoBehaviour {

    //Holds the enemy lasers
    private float fireRate = 0.5f;
    private float fireTime = 1.0f;

    public GameObject projectile;

    //Used to locate and face player
    GameObject[] players;
    GameObject closestPlayer;

    Transform myTransform;

    private float rotationSpeed = 2.0f;
    private float adjRotationSpeed;
    private Quaternion targetRotation;

    // Use this for initialization
    void Start () {
        myTransform = this.transform;
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
        LookAtPlayer();

        fireTime += Time.deltaTime;

        if (fireTime >= fireRate)
        {
            Instantiate(projectile, myTransform.position, myTransform.rotation);
            fireTime = 0;
        }
    }


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
            targetRotation = Quaternion.LookRotation(new Vector3(0, 0, -100) - myTransform.position);
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
