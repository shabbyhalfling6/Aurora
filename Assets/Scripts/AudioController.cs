using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    //Holds the differnt Channels for tuning
    public AudioSource BGM;
    public AudioSource SFX;
    public AudioSource EXP;

    //Holds the shound that the player makes when firing
    public AudioClip[] playerShot;

    //Holds the sound that the enemy makes on death
    public AudioClip[] enemyDeath;

    //Holds the random number for minor varioations in sounds
    private int rand;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Playes the desired clips on the desired chanel
    public void playSound(AudioSource source, AudioClip[] clip,float setVolume)
    {
        rand = Random.Range(0, clip.Length);
        source.volume = setVolume;
        source.PlayOneShot(clip[rand]);
    }
}
