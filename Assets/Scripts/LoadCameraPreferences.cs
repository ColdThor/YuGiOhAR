using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCameraPreferences : MonoBehaviour
{
    public Toggle cameratoggle;


    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "options")
        {
            var cam = PlayerPrefs.GetString("Camera", "Default value");
            if (cam.Equals("yes"))
            {
                cameratoggle.isOn = true;
            }
            if (cam.Equals("no"))
            {
                cameratoggle.isOn = false;
            }
        }
        
    }

}
