using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Down : MonoBehaviour
{
    GameObject MainCam; // Reference to Parent

    void Start()
    {
        MainCam = this.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Triggers bool BoxBorderDown within the parent
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderDown = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) // BoxBorderDown is only true while the player collides with it
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderDown = false;
        }

    }
}