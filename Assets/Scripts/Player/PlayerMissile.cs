using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {


    private Transform myTransform;

    private float projectileSpeed = 10.0f;

    private GameObject[] enemyList;

    private GameObject closestEnemyUnit;

    private float rotationSpeed = 10.0f;

    private float lifeTime;
    private float lifeTimeDuration = 1f;

    // Use this for initialization
    void Start()
    {
        myTransform = this.transform;
        lifeTime = Time.time + lifeTimeDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        //Movement
        myTransform.position += Time.deltaTime * projectileSpeed * transform.forward;
        closestEnemyUnit = FindClosestEnemyUnit();

        if (closestEnemyUnit != null)
        {
            //Smooth Lock
            //Determine traget rotation. this is the rotation if the transfrom looks at the target
            Quaternion targetRotation = Quaternion.LookRotation(closestEnemyUnit.transform.position - myTransform.position);

            //Smoothly roatate towards the target point
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Time.time > lifeTime)
        {
            Destroy(this.gameObject);
        }
    }


    //Enemy Detection
    //Return closest enemy in enemyList
    private GameObject FindClosestEnemyUnit()
    {
        float distance = Mathf.Infinity;
        Vector3 position = myTransform.position;

        foreach (GameObject enemyUnit in enemyList)
        {
            Vector3 diff = enemyUnit.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                closestEnemyUnit = enemyUnit;
                distance = curDistance;
            }
        }
        return closestEnemyUnit;
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
