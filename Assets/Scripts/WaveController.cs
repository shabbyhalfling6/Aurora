using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

    private Transform myTransform;

    public GameObject[] waves;
    public GameObject miniBoss;

    private float waveTimer = 185.0f;
    private float spawningDelay = 7.0f;
    private float spawningTime = 15.0f;

	// Use this for initialization
	void Start () {
        myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        waveTimer -= Time.deltaTime;
        Spawning();
	}

    void Spawning()
    {
        spawningTime += Time.deltaTime;

        if(waveTimer > 144)
        {
            //Wave1
            if(spawningTime >= spawningDelay)
            {
                Instantiate(waves[0],myTransform.position,myTransform.rotation);
                spawningTime = 0;
            }
        } 
        else
        {
            if(waveTimer > 108)
            {
                //Wave2
                if (spawningTime >= spawningDelay)
                {
                    Instantiate(waves[1], myTransform.position, myTransform.rotation);
                    spawningTime = 0;
                }
            }
            else
            {
                if (waveTimer > 72)
                {
                    //Wave 3
                    if (spawningTime >= spawningDelay)
                    {
                        Instantiate(waves[2], myTransform.position, myTransform.rotation);
                        spawningTime = 0;
                    }
                }
                else
                {
                    if (waveTimer > 36)
                    {
                        //Wave 4
                        if (spawningTime >= spawningDelay)
                        {
                            Instantiate(waves[3], myTransform.position, myTransform.rotation);
                            spawningTime = 0;
                        }
                    }
                    else
                    {
                        if (waveTimer > 0)
                        {
                            //wave 5
                            if (spawningTime >= spawningDelay)
                            {
                                Instantiate(waves[4], myTransform.position, myTransform.rotation);
                                spawningTime = 0;
                            }
                        }
                        else
                        {
                            if(waveTimer<=0)
                            {
                                Instantiate(miniBoss, new Vector3(0,0,7), Quaternion.Euler(0,0,0));
                                Destroy(this.gameObject);
                            }
                        }
                        
                    }
                }
            }
        }

    }
}
