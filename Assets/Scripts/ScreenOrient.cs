﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrient : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

}
