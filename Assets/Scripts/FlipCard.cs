using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{

    public int fps = 60;
    public float RotateDegreePerSecond = 180f;
    public bool IsFaceUp = false;

    const float FLIP_LIMIT_DEGREE = 180f;

    float waitTime;
    bool IsAnimationProcessing = false;


    void Start()
    {
        waitTime = 1.0f / fps;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnMouseDown()
    {
       if(IsAnimationProcessing)
        {
            return;
        }
        StartCoroutine(flip() );
    }

    IEnumerator flip()
    {
        IsAnimationProcessing = true;

        bool done = false;
        while(!done)
        {
            float degree = RotateDegreePerSecond * Time.deltaTime;

            if(IsFaceUp)
            {
                degree = -degree;
            }

            transform.Rotate(new Vector3(0,degree,0));

            if(FLIP_LIMIT_DEGREE < transform.eulerAngles.y)
            {
                transform.Rotate(new Vector3(0, -degree, 0));
              //  SHOW TEXT, SHOW BACK & ADD TO COLLECTION
            }


            yield return new WaitForSeconds(waitTime);
        }

        IsFaceUp = !IsFaceUp;
        IsAnimationProcessing = false;
    }



}
