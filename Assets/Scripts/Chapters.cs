﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapters : MonoBehaviour
{


    public Text chapter1;
    public Text chapter2;
    public Text chapter3;
    public Text chapter4;
    public Text chapter5;
    public Text chapter6;

    void Start()
    {

        //TESTING
        googleSignIn.story_progress = 1;

        switch (googleSignIn.story_progress)
        {
            case 1:
                chapter1.text = "";
                chapter2.text = "LOCKED";
                chapter3.text = "LOCKED";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 2:
                chapter1.text = "COMPLETED";
                chapter2.text = "";
                chapter3.text = "LOCKED";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 3:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "";
                chapter4.text = "LOCKED";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 4:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "";
                chapter5.text = "LOCKED";
                chapter6.text = "LOCKED";
                break;
            case 5:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "";
                chapter6.text = "LOCKED";
                break;
            case 6:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "COMPLETED";
                chapter6.text = "";
                break;
            case 7:
                chapter1.text = "COMPLETED";
                chapter2.text = "COMPLETED";
                chapter3.text = "COMPLETED";
                chapter4.text = "COMPLETED";
                chapter5.text = "COMPLETED";
                chapter6.text = "COMPLETED";
                break;
        }
    }



   public void onFirstChapter()
    {
        SceneManager.LoadScene(6);
    }


}
