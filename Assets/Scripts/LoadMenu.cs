using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class LoadMenu : MonoBehaviour
{

    public static bool camefromcollection;
    public static bool camefromdiscover;
    public static bool camefromjourney;

    public Canvas main;
    public Canvas game;
    public Canvas options;
    public Canvas collection;
    public Canvas card_scene;
    public Text nametext;
    public Text optionstext;
    public Image audiotext;
    public Image artext;
    public Toggle toggler;
    public Toggle ar_toggler;

    private EventTrigger trigger;


    void Start()
    {
        if(!AndroidBackButton.gotogame)
        {
            main.enabled = true;
            game.enabled = false;
            options.enabled = false;
            collection.enabled = false;
            card_scene.enabled = false;
        } else
        {
            main.enabled = false;
            game.enabled = true;
            options.enabled = false;
            collection.enabled = false;
            card_scene.enabled = false;
            AndroidBackButton.gotogame = false;
        }
        

    }

    void showCard(int pocet)
    {
        GameObject card = GameObject.Find("FullCard");
        card.GetComponent<Button>().image.sprite = PopulateCollection.cards[PopulateCollection.card_clicked];

        card.AddComponent(typeof(EventTrigger));
        trigger = card.GetComponent<EventTrigger>();



        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => {
            main.enabled = false;
            game.enabled = false;
            card_scene.enabled = false;
            options.enabled = false;
            collection.enabled = true;
        });
        trigger.triggers.Add(entry);


    }


    public void SceneLoader(int SceneIndex)
    {
        camefromcollection = false;
        camefromdiscover = false;
        camefromjourney = false;

        if(SceneIndex == 1 )
        {
            SceneManager.LoadScene(SceneIndex);
        }



        if (SceneIndex == 3)
        {
          
            if (googleSignIn.userid == null)
            {
                main.enabled = false;
                game.enabled = false;
                card_scene.enabled = false;
                camefromdiscover = true;
                options.enabled = true;
                nametext.text = "YOU MUST BE LOGGED IN TO DISCOVER";
                toggler.gameObject.SetActive(false);
                ar_toggler.gameObject.SetActive(false);
                audiotext.enabled = false;
                artext.enabled = false;
                optionstext.enabled = false;
            } else
            {
                SceneManager.LoadScene(SceneIndex);
            }
          
        }
        else
        {
            if (SceneIndex == 5)
            {
                DialogueSystem.diag_inc = 0;

                if (googleSignIn.userid == null)
                {
                    main.enabled = false;
                    game.enabled = false;
                    card_scene.enabled = false;
                    camefromjourney = true;
                    options.enabled = true;
                    nametext.text = "YOU MUST BE LOGGED IN TO ENTER STORY";
                    toggler.gameObject.SetActive(false);
                    ar_toggler.gameObject.SetActive(false);
                    audiotext.enabled = false;
                    artext.enabled = false;
                    optionstext.enabled = false;
                }
                else
                {
                    if(googleSignIn.story_progress == 7)
                    {
                        SceneManager.LoadScene(7);
                    } else
                    {
                        SceneManager.LoadScene(SceneIndex);
                    }
                  
                }
            }
        }







    }

    public void showGameMenu()
    {
        main.enabled = false;
        game.enabled = true;
        options.enabled = false;
        collection.enabled = false;
        card_scene.enabled = false;
    }

    public void showMainMenu()
    {
        main.enabled = true;
        game.enabled = false;
        options.enabled = false;
        collection.enabled = false;
        card_scene.enabled = false;
    }

    public void showOptions()
    {
        main.enabled = false;
        game.enabled = false;
        card_scene.enabled = false;
        options.enabled = true;
        collection.enabled = false;
    }

    public void showCollection()
    {
        main.enabled = false;
        game.enabled = false;
        card_scene.enabled = false;
        options.enabled = false;
        if (googleSignIn.userid == null)
        {
            camefromcollection = true;
            options.enabled = true;
            nametext.text = "YOU MUST BE LOGGED IN TO VIEW YOUR COLLECTION";
            toggler.gameObject.SetActive(false);
            ar_toggler.gameObject.SetActive(false);
            audiotext.enabled = false;
            artext.enabled = false;
            optionstext.enabled = false;
        }
        else
        {
            collection.enabled = true;
        }

    }


    public void Quit()
    {
        Application.Quit();
    }

    public void showFullScreenCard()
    {
    
        GameObject.Find("Canvas_collection").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_fullscreencard").GetComponent<Canvas>().enabled = true;
        showCard(21);
    }





}
