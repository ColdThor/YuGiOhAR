using Proyecto26;
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


            Player player = new Player();
            RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
            {

                player = response;
            });

            switch (random)
            {
                case 0: GetComponent<SpriteRenderer>().sprite = cards[0]; FlipCard.obtained_card_string = "You´ve obtained Blue Eyes White Dragon"; player.blue_acquired = true; googleSignIn.userdata[0] = true; break;
                case 1: GetComponent<SpriteRenderer>().sprite = cards[1]; FlipCard.obtained_card_string = "You´ve obtained Dark Magician"; player.dark_acquired = true; googleSignIn.userdata[1] = true; break;
                case 2: GetComponent<SpriteRenderer>().sprite = cards[2]; FlipCard.obtained_card_string = "You´ve obtained Summoned Skull"; player.skull_acquired = true; googleSignIn.userdata[2] = true; break;
                case 3: GetComponent<SpriteRenderer>().sprite = cards[3]; FlipCard.obtained_card_string = "You´ve obtained Gaia the Fierce Knight"; player.gaia_acquired = true; googleSignIn.userdata[3] = true; break;
                case 4: GetComponent<SpriteRenderer>().sprite = cards[4]; FlipCard.obtained_card_string = "You´ve obtained Obelisk the Tormentor"; player.obelisk_acquired = true; googleSignIn.userdata[4] = true; break;
                case 5: GetComponent<SpriteRenderer>().sprite = cards[5]; FlipCard.obtained_card_string = "You´ve obtained Elemental Hero Neos"; player.neos_acquired = true; googleSignIn.userdata[5] = true; break;
                case 6: GetComponent<SpriteRenderer>().sprite = cards[6]; FlipCard.obtained_card_string = "You´ve obtained Ancient Gear Golem"; player.golem_acquired = true; googleSignIn.userdata[6] = true; break;
                case 7: GetComponent<SpriteRenderer>().sprite = cards[7]; FlipCard.obtained_card_string = "You´ve obtained Celtic Warrior"; player.celtic_acquired = true; googleSignIn.userdata[7] = true; break;
                case 8: GetComponent<SpriteRenderer>().sprite = cards[8]; FlipCard.obtained_card_string = "You´ve obtained Cyber Dragon"; player.cyber_acquired = true; googleSignIn.userdata[8] = true; break;
                case 9: GetComponent<SpriteRenderer>().sprite = cards[9]; FlipCard.obtained_card_string = "You´ve obtained Dark Magician Girl"; player.girl_acquired = true; googleSignIn.userdata[9] = true; break;
                case 10: GetComponent<SpriteRenderer>().sprite = cards[10]; FlipCard.obtained_card_string = "You´ve obtained Destiny Hero Dreadmaster"; player.dreadmaster_acquired = true; googleSignIn.userdata[10] = true; break;
                case 11: GetComponent<SpriteRenderer>().sprite = cards[11]; FlipCard.obtained_card_string = "You´ve obtained Gate Guardian"; player.gate_acquired = true; googleSignIn.userdata[11] = true; break;
                case 12: GetComponent<SpriteRenderer>().sprite = cards[12]; FlipCard.obtained_card_string = "You´ve obtained Harpie Lady Sisters"; player.harpie_acquired = true; googleSignIn.userdata[12] = true; break;
                case 13: GetComponent<SpriteRenderer>().sprite = cards[13]; FlipCard.obtained_card_string = "You´ve obtained Rainbow Dragon"; player.rainbow_acquired = true; googleSignIn.userdata[13] = true; break;
                case 14: GetComponent<SpriteRenderer>().sprite = cards[14]; FlipCard.obtained_card_string = "You´ve obtained Red Eyes Black Dragon"; player.red_acquired = true; googleSignIn.userdata[14] = true; break;
                case 15: GetComponent<SpriteRenderer>().sprite = cards[15]; FlipCard.obtained_card_string = "You´ve obtained King Rex"; player.rex_acquired = true; googleSignIn.userdata[15] = true; break;
                case 16: GetComponent<SpriteRenderer>().sprite = cards[16]; FlipCard.obtained_card_string = "You´ve obtained Slifer the Sky Dragon"; player.slifer_acquired = true; googleSignIn.userdata[16] = true; break;
                case 17: GetComponent<SpriteRenderer>().sprite = cards[17]; FlipCard.obtained_card_string = "You´ve obtained Time Wizard"; player.time_acquired = true; googleSignIn.userdata[17] = true; break;
                case 18: GetComponent<SpriteRenderer>().sprite = cards[18]; FlipCard.obtained_card_string = "You´ve obtained Water Dragon"; player.water_acquired = true; googleSignIn.userdata[18] = true; break;
                case 19: GetComponent<SpriteRenderer>().sprite = cards[19]; FlipCard.obtained_card_string = "You´ve obtained Winged Dragon of Ra"; player.ra_acquired = true; googleSignIn.userdata[19] = true; break;
                case 20: GetComponent<SpriteRenderer>().sprite = cards[20]; FlipCard.obtained_card_string = "You´ve obtained Yubel"; player.yubel_acquired = true; googleSignIn.userdata[20] = true; break;

            }



            RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);

            googleSignIn gsi = new googleSignIn();
            gsi.googleSignInButton();



            var bounds = GetComponent<SpriteRenderer>().sprite.bounds;
            transform.localScale = new Vector3(1.1f, 1.1f, 1);
        }



        



    }
}
