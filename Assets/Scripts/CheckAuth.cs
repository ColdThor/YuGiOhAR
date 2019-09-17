using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAuth : MonoBehaviour
{
     private static bool firsttime = true;
    void Start()
    {
        if(firsttime)
        {
            firsttime = false;
            try
            {
              googleSignIn.auth.SignOut();
              
            }
            catch(Exception e) { }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
