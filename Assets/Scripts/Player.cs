using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Player
{
    public string username;
    public string userid;


    public Boolean blue_acquired;
    public Boolean dark_acquired;
    public Boolean skull_acquired;
    public Boolean gaia_acquired;
    public Boolean obelisk_acquired;
    public Boolean neos_acquired;
    public Boolean golem_acquired;
    public Boolean celtic_acquired;
    public Boolean cyber_acquired;
    public Boolean girl_acquired;
    public Boolean dreadmaster_acquired;
    public Boolean gate_acquired;
    public Boolean harpie_acquired;
    public Boolean rainbow_acquired;
    public Boolean red_acquired;
    public Boolean rex_acquired;
    public Boolean slifer_acquired;
    public Boolean time_acquired;
    public Boolean water_acquired;
    public Boolean ra_acquired;
    public Boolean yubel_acquired;



    public Player()
    {
        username = googleSignIn.username;
        userid = googleSignIn.userid;


        blue_acquired = true;
        dark_acquired = false;
        skull_acquired = false;
        gaia_acquired = false;
        obelisk_acquired = false;
        neos_acquired = false;
        golem_acquired = false;
        celtic_acquired = false;
        cyber_acquired = true;
        girl_acquired = false;
        dreadmaster_acquired = false;
        gate_acquired = false;
        harpie_acquired = false;
        rainbow_acquired = false;
        red_acquired = false;
        rex_acquired = false;
        slifer_acquired = false;
        time_acquired = true;
        water_acquired = false;
        ra_acquired = false;
        yubel_acquired = false;


    }

}
