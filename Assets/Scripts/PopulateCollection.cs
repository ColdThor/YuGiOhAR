using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using Proyecto26;

public class PopulateCollection : MonoBehaviour
{



    public static int card_clicked;

    public GameObject card;

    public int pocet;


    public static Sprite[] cards;
    public static Sprite[] unobtained;








    void Start()
    {
    
      

        Populate();

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(2);
            }
        }
        }








    void Populate()
    {

        GameObject[] newObj;

       newObj = new GameObject[pocet];

       cards = new Sprite[pocet];
       unobtained = new Sprite[pocet];

        // 3D COMPATIBLE UNOBTAINED (GRAYED OUT) CARDS


        unobtained[0] = Resources.Load<Sprite>("blue_eyes_white_dragon_gray");
        unobtained[1] = Resources.Load<Sprite>("dark_magician_gray");
        unobtained[2] = Resources.Load<Sprite>("summoned_skull_gray");
        unobtained[3] = Resources.Load<Sprite>("gaia_gray");
        unobtained[4] = Resources.Load<Sprite>("obelisk_gray");
        unobtained[5] = Resources.Load<Sprite>("neos_gray");

        // END OF UNOBTAINED (GRAYED OUT) CARDS

        // END OF 3D COMPATIBLE

        unobtained[6] = Resources.Load<Sprite>("ancient_gear_golem_gray");
        unobtained[7] = Resources.Load<Sprite>("celtic_warrior_gray");
        unobtained[8] = Resources.Load<Sprite>("cyber_dragon_gray");
        unobtained[9] = Resources.Load<Sprite>("dark_magician_girl_gray");
        unobtained[10] = Resources.Load<Sprite>("dreadmaster_gray");
        unobtained[11] = Resources.Load<Sprite>("gate_guard_gray");
        unobtained[12] = Resources.Load<Sprite>("harpie_lady_gray");
        unobtained[13] = Resources.Load<Sprite>("rainbow_dragon_gray");
        unobtained[14] = Resources.Load<Sprite>("red_eyes_gray");
        unobtained[15] = Resources.Load<Sprite>("rex_gray");
        unobtained[16] = Resources.Load<Sprite>("slifer_gray");
        unobtained[17] = Resources.Load<Sprite>("time_wizard_gray");
        unobtained[18] = Resources.Load<Sprite>("water_dragon_gray");
        unobtained[19] = Resources.Load<Sprite>("winged_dragon_gray");
        unobtained[20] = Resources.Load<Sprite>("yubel_gray");


     
        // 3D COMPATIBLE

        cards[0] = Resources.Load<Sprite>("blue_eyes_white_dragon");
        cards[1] = Resources.Load<Sprite>("dark_magician");
        cards[2] = Resources.Load<Sprite>("summoned_skull");
        cards[3] = Resources.Load<Sprite>("gaia");
        cards[4] = Resources.Load<Sprite>("obelisk");
        cards[5] = Resources.Load<Sprite>("neos");


        // END OF 3D COMPATIBLE

        cards[6] = Resources.Load<Sprite>("ancient_gear_golem");
        cards[7] = Resources.Load<Sprite>("celtic_warrior");
        cards[8] = Resources.Load<Sprite>("cyber_dragon");
        cards[9] = Resources.Load<Sprite>("dark_magician_girl");
        cards[10] = Resources.Load<Sprite>("dreadmaster");
        cards[11] = Resources.Load<Sprite>("gate_guard");
        cards[12] = Resources.Load<Sprite>("harpie_lady");
        cards[13] = Resources.Load<Sprite>("rainbow_dragon");
        cards[14] = Resources.Load<Sprite>("red_eyes");
        cards[15] = Resources.Load<Sprite>("rex");
        cards[16] = Resources.Load<Sprite>("slifer");
        cards[17] = Resources.Load<Sprite>("time_wizard");
        cards[18] = Resources.Load<Sprite>("water_dragon");
        cards[19] = Resources.Load<Sprite>("winged_dragon");
        cards[20] = Resources.Load<Sprite>("yubel");



  

        for (int i=0; i< pocet;i++)
        {
            newObj[i] = (GameObject)Instantiate(card, transform);
            newObj[i].transform.SetParent(transform, false);
            var index = i;
            UnityEngine.Events.UnityAction action1 = () => { cardClicked(index); };
            newObj[i].GetComponent<Button>().onClick.AddListener(action1);

            if(googleSignIn.userdata[i] == false)
            {
                newObj[i].GetComponent<Image>().sprite = unobtained[i];
            } else
            {
                newObj[i].GetComponent<Image>().sprite = cards[i];
            }
            

           

        }


        void cardClicked(int index)
        {
            card_clicked = index;
            SceneManager.LoadScene(4);
        }


    }

   
}
