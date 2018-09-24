using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewOptionNenu : MonoBehaviour {

   // public Slider BGMVol;
    //public Slider SFXVol;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FinishOptions()
    {
       // PlayerPrefs.SetFloat("BGMVol", BGMVol.value);
       // PlayerPrefs.SetFloat("SFXVol", SFXVol.value);
       // PlayerPrefs.Save();
        Application.LoadLevel("MainMenu");
    }
}
