using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class FaceUpCard : MonoBehaviour
    {
        private static Sprite[] cards;



        void Start()
        {

            cards = new Sprite[21];

            cards[0] = Resources.Load<Sprite>("blue_eyes_white_dragon");
            cards[1] = Resources.Load<Sprite>("dark_magician");
            cards[2] = Resources.Load<Sprite>("summoned_skull");
            cards[3] = Resources.Load<Sprite>("gaia");
            cards[4] = Resources.Load<Sprite>("obelisk");
            cards[5] = Resources.Load<Sprite>("neos");
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


            int random = UnityEngine.Random.Range(0, 21);
            while(googleSignIn.userdata[random] == true)
            {
                 random = UnityEngine.Random.Range(0, 21);
            }

            GetComponent<SpriteRenderer>().sprite = cards[random];
            googleSignIn.userdata[random] = true;

            Player player = new Player();
            RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
            {

                player = response;
                
                switch (random)
                {
                    case 0: FlipCard.obtained_card_string = "You´ve obtained Blue Eyes White Dragon"; player.blue_acquired = true;  break;
                    case 1: FlipCard.obtained_card_string = "You´ve obtained Dark Magician"; player.dark_acquired = true;  break;
                    case 2: FlipCard.obtained_card_string = "You´ve obtained Summoned Skull"; player.skull_acquired = true;  break;
                    case 3: FlipCard.obtained_card_string = "You´ve obtained Gaia the Fierce Knight"; player.gaia_acquired = true;  break;
                    case 4: FlipCard.obtained_card_string = "You´ve obtained Obelisk the Tormentor"; player.obelisk_acquired = true;  break;
                    case 5: FlipCard.obtained_card_string = "You´ve obtained Elemental Hero Neos"; player.neos_acquired = true;  break;
                    case 6: FlipCard.obtained_card_string = "You´ve obtained Ancient Gear Golem"; player.golem_acquired = true;  break;
                    case 7: FlipCard.obtained_card_string = "You´ve obtained Celtic Warrior"; player.celtic_acquired = true;  break;
                    case 8: FlipCard.obtained_card_string = "You´ve obtained Cyber Dragon"; player.cyber_acquired = true;  break;
                    case 9: FlipCard.obtained_card_string = "You´ve obtained Dark Magician Girl"; player.girl_acquired = true;  break;
                    case 10: FlipCard.obtained_card_string = "You´ve obtained Destiny Hero Dreadmaster"; player.dreadmaster_acquired = true;  break;
                    case 11: FlipCard.obtained_card_string = "You´ve obtained Gate Guardian"; player.gate_acquired = true;  break;
                    case 12: FlipCard.obtained_card_string = "You´ve obtained Harpie Lady Sisters"; player.harpie_acquired = true;  break;
                    case 13: FlipCard.obtained_card_string = "You´ve obtained Rainbow Dragon"; player.rainbow_acquired = true;  break;
                    case 14: FlipCard.obtained_card_string = "You´ve obtained Red Eyes Black Dragon"; player.red_acquired = true;  break;
                    case 15: FlipCard.obtained_card_string = "You´ve obtained King Rex"; player.rex_acquired = true;  break;
                    case 16: FlipCard.obtained_card_string = "You´ve obtained Slifer the Sky Dragon"; player.slifer_acquired = true;  break;
                    case 17: FlipCard.obtained_card_string = "You´ve obtained Time Wizard"; player.time_acquired = true;  break;
                    case 18: FlipCard.obtained_card_string = "You´ve obtained Water Dragon"; player.water_acquired = true;  break;
                    case 19: FlipCard.obtained_card_string = "You´ve obtained Winged Dragon of Ra"; player.ra_acquired = true;  break;
                    case 20: FlipCard.obtained_card_string = "You´ve obtained Yubel"; player.yubel_acquired = true;  break;

                }

            

                RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);


            });

    

     

         



            var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
            transform.localScale = new Vector3(1.1f, 1.1f, 1);
        }



        



    }
}
