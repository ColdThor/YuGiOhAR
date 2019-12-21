using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GPSCollider : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.tag == "MilleniumItem")
                {
                    MilleniumPuzzle item = hit.transform.GetComponent<MilleniumPuzzle>();
                    SceneManager.LoadScene(4);
                }
            }
        }
    }
}
