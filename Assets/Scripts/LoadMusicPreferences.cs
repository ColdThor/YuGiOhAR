using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMusicPreferences : MonoBehaviour
{

    public Toggle audiotoggle;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "options")
        {
            var music = PlayerPrefs.GetString("Music", "Default value");
            if (music.Equals("yes"))
            {
                audiotoggle.isOn = true;
            }
            if (music.Equals("no"))
            {
                audiotoggle.isOn = false;
            } 
        }
        else
        {
            var music = PlayerPrefs.GetString("Music", "Default value");
            if (music.Equals("no"))
            {

                ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Stop();

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
