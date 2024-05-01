using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BB_Left : MonoBehaviour
{
    GameObject MainCam; // Reference to Parent
    
    void Start()
    {
        MainCam = this.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Triggers bool BoxBorderLeft within the parent
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderLeft = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision) // BoxBorderLeft is only true while the player collides with it
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderLeft = false;
        }
       
    }

}
