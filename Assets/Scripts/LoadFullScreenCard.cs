using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadFullScreenCard : MonoBehaviour
{

    public GameObject card;
    public EventTrigger trigger;


    void Start()
    {
        showCard(21);
    }



    void showCard(int pocet)
    {
        card.GetComponent<Image>().sprite = PopulateCollection.cards[PopulateCollection.card_clicked];

        card.AddComponent(typeof(EventTrigger));
        trigger = card.GetComponent<EventTrigger>();



        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => {
            SceneManager.LoadScene(3);
        });
        trigger.triggers.Add(entry);


    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
