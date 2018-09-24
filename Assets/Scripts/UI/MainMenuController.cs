using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    //Loads a specified level
    //FOR DEMO LOAD LEVEL 1
    public void loadLevel()
    {
        Application.LoadLevel("ShipSelection");
    }
    public void loadOptions()
    {
        Application.LoadLevel("Options");
    }

    //Exits the game (Doesnt work in editor but does work in executable)
    public void quitGame()
    {
        Application.Quit();
    }

}
