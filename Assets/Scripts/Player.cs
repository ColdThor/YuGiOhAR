using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Player
{
    public string username;
    public string userid;


    public Boolean blue_acquired { get; set; }
    public Boolean dark_acquired { get; set; }
    public Boolean skull_acquired { get; set; }
    public Boolean gaia_acquired { get; set; }
    public Boolean obelisk_acquired { get; set; }
    public Boolean neos_acquired { get; set; }
    public Boolean golem_acquired { get; set; }
    public Boolean celtic_acquired { get; set; }
    public Boolean cyber_acquired { get; set; }
    public Boolean girl_acquired { get; set; }
    public Boolean dreadmaster_acquired { get; set; }
    public Boolean gate_acquired { get; set; }
    public Boolean harpie_acquired { get; set; }
    public Boolean rainbow_acquired { get; set; }
    public Boolean red_acquired { get; set; }
    public Boolean rex_acquired { get; set; }
    public Boolean slifer_acquired { get; set; }
    public Boolean time_acquired { get; set; }
    public Boolean water_acquired { get; set; }
    public Boolean ra_acquired { get; set; }
    public Boolean yubel_acquired { get; set; }



    public Player()
    {
        username = googleSignIn.username;
        userid = googleSignIn.userid;

    }


    public void newCollection()
    {
        blue_acquired = false;
        dark_acquired = false;
        skull_acquired = false;
        gaia_acquired = false;
        obelisk_acquired = false;
        neos_acquired = false;
        golem_acquired = false;
        celtic_acquired = false;
        cyber_acquired = false;
        girl_acquired = false;
        dreadmaster_acquired = false;
        gate_acquired = false;
        harpie_acquired = false;
        rainbow_acquired = false;
        red_acquired = false;
        rex_acquired = false;
        slifer_acquired = false;
        time_acquired = false;
        water_acquired = false;
        ra_acquired = false;
        yubel_acquired = false;
    }


    



}
