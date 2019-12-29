using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueSystem : MonoBehaviour
{

    public UnityEngine.Video.VideoClip videoClip;
    public Image protagonist;
    public Image antagonist;
    public Canvas dialogueCanvas;
    public Canvas chapter_select;
    public Text diag;

    GraphicRaycaster raycaster;

    private int story_chapter = 0;
    private int diag_inc = 0;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (Player.story_progress == 0)
        {
         dialogueCanvas.enabled = false;
              GameObject camera = GameObject.Find("Main Camera");
              var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
              videoPlayer.playOnAwake = true;
              videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.CameraNearPlane;
              videoPlayer.targetCameraAlpha = 1f;
              videoPlayer.clip = videoClip;
              videoPlayer.loopPointReached += EndReached;
        } else
        {
            dialogueCanvas.enabled = false;
            chapter_select.enabled = true;
        }

    }


    void Awake()
    {
        this.raycaster = GetComponent<GraphicRaycaster>();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.enabled = false;
        dialogueCanvas.enabled = true;
        startStory();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && story_chapter == 1)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();
            switch(diag_inc)
            {
                case 0:
                    antagonist.gameObject.SetActive(true);
                    protagonist.gameObject.SetActive(true);
                    antagonist.color = Color.black;
                    protagonist.color = Color.white;
                    diag.text = "Kaiba: Pegasus! Your games will end here and now. This madness will stop";
                    diag_inc++; 
                    break;
                case 1:
                    antagonist.color = Color.white;
                    protagonist.color = Color.black;
                    diag.text = "Pegasus: Oh, Kaiba boy! You know nothing about my powers";
                    diag_inc++;
                    break;
                case 2:
                    antagonist.color = Color.black;
                    protagonist.color = Color.white;
                    diag.text = "Kaiba: I know you are keeping Yugi locked, and I will save him, I owe him that much";
                    diag_inc++;
                    break;
                case 3:
                    antagonist.color = Color.white;
                    protagonist.color = Color.black;
                    diag.text = "Pegasus: Then you will have to face monsters you´ve never seen before dear Kaiba";
                    diag_inc++;
                    break;
                case 4:
                    antagonist.color = Color.black;
                    protagonist.color = Color.white;
                    diag.text = "Kaiba: I am ready, are you?";
                    diag_inc++;
                    break;
            }
        }
    }






    void startStory()
    {
        diag_inc = 0;
        story_chapter = 1;
    }


}
