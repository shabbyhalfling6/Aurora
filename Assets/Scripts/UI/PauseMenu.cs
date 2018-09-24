using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private bool isPaused = false;

    public GameObject pauseScreen;
    private GameObject visablePauseScreen;

	// Use this for initialization
	void Start () {
	
	}
	//re
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("escape")||Input.GetButtonDown("Pause"))
        {
            togglePaused();
        }
	}

    //Swaps the game from pause to unPaused
    public void togglePaused()
    {
        if (isPaused == false)
        {
            Instantiate(pauseScreen);
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            if (isPaused == true)
            {
                findPauseScreen();
                Destroy(visablePauseScreen.gameObject);
                Time.timeScale = 1;
                isPaused = false;
            }
        }
    }

    //Locates the current pause menu
    private void findPauseScreen()
    {
        visablePauseScreen = GameObject.FindGameObjectWithTag("PauseMenu");
    }
}
