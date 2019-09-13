using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class DarkMagicianController : MonoBehaviour
{


    private Rigidbody rb;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
      //X-ová os
      float x = CrossPlatformInputManager.GetAxis("Horizontal");
      //Y-ová os
      float y = CrossPlatformInputManager.GetAxis("Vertical");

      // Z-tá os je 0, lebo model sa nebude pohybovať na tej osi
      Vector3 movement = new Vector3(x,0,y);

        

      // rýchlosť pohybu
      rb.velocity = movement* 1f;

      if(x != 0 && y != 0) {
        // Aby model smeroval tam, kde používateľ ťahá joystick
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,Mathf.Atan2(x,y) * Mathf.Rad2Deg,transform.eulerAngles.z);

      }

    }
}
