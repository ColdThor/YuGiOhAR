using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LoadMenu : MonoBehaviour
{

    public static Boolean camefromcollection;
   
public void SceneLoader(int SceneIndex)
    {
        camefromcollection = false;

        if(SceneIndex == 1 )
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

        if (SceneIndex == 3)
        {

            if(googleSignIn.userid == null)
            {
                camefromcollection = true;
                SceneManager.LoadScene(6);
            } else
            {
                SceneManager.LoadScene(SceneIndex);
            } 
        }
        else
        {
            SceneManager.LoadScene(SceneIndex);
        }


    }

}
