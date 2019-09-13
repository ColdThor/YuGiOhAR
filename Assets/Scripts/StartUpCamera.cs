using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().Pause();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var music = PlayerPrefs.GetString("Music", "Default value");
            if (music.Equals("yes"))
            {
                ThemeSongScript.Instance.gameObject.GetComponent<AudioSource>().UnPause();
            }
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(2);
        }
    }
}
