using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Proyecto26;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{

    public UnityEngine.Video.VideoClip videoClip;
    public Image protagonist;
    public Image antagonist;
    public Canvas dialogueCanvas;
    public Text diag;




    private VideoPlayer videoPlayer;

    private bool videoplaying = false;


    private int story_chapter = 0;
    private int diag_inc = 0;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        if (googleSignIn.story_progress == 0)
        {
         dialogueCanvas.enabled = false;
              GameObject camera = GameObject.Find("Main Camera");
              videoPlayer = camera.AddComponent<VideoPlayer>();
              videoPlayer.playOnAwake = true;
              videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
              videoPlayer.targetCameraAlpha = 1f;
              videoPlayer.clip = videoClip;
              videoplaying = true;
              videoPlayer.loopPointReached += EndReached;
        } 

    }


  

    void EndReached(VideoPlayer vp)
    {
        vp.enabled = false;
        videoplaying = false;
        dialogueCanvas.enabled = true;
        startStory();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0) && videoplaying)
        {
            videoPlayer.enabled = false;
            videoplaying = false;
            dialogueCanvas.enabled = true;
            startStory();
        }


            if (Input.GetMouseButtonDown(0) && story_chapter == 1)
        {
            FirstChapter();
        }
    }


    public void FirstChapter()
    {
            protagonist.sprite = Resources.Load<Sprite>("kaiba_dl");
            antagonist.sprite = Resources.Load<Sprite>("pegasus_dl");

        switch (diag_inc)
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

                Player player = new Player();
                RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
                {
                    player.story_progress = 1;
                    RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
                });
                googleSignIn.story_progress = 1;
                chapterControl();

                break;
        }
    }

    public void SecondChapter()
    {

    }



    public void chapterControl()
    {
        SceneManager.LoadScene(7);
    }




    void startStory()
    {
        diag_inc = 0;
        story_chapter = 1;
    }


}
