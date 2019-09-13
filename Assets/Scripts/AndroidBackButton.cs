using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidBackButton : MonoBehaviour
{


    public int SceneIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneIndex == 4)
            {

                SceneManager.LoadScene(2);
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music.Equals("yes"))
                {
                    ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
                }
            }

            if (SceneIndex == 2)
            {
                SceneManager.LoadScene(0);
            }
            if (SceneIndex == 0)
            {
                Application.Quit();
            }

            if (SceneIndex == 7)
            {
                SceneManager.LoadScene(2);
                var music = PlayerPrefs.GetString("Music", "Default value");
                if (music.Equals("yes"))
                {
                    ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
                }
            }


        }
    }
}
