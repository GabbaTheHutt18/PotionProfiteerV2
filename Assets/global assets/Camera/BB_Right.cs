using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_Right : MonoBehaviour
{
    GameObject MainCam; // Reference to Parent

    void Start()
    {
        MainCam = this.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Triggers bool BoxBorderRight within the parent
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderRight = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision) // BoxBorderRight is only true while the player collides with it
    {
        if (collision.gameObject.tag == "Player")
        {
            MainCam.GetComponent<MovingCameraScript>().BoxBorderRight = false;
        }

    }
}
