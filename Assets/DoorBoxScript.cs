using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBoxScript : MonoBehaviour
{
    private bool InArea = false;

    void Update()
    {
        if (InArea == true && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = false;
        }
    }

    void Interaction()
    {
        transform.GetChild(0).GetComponent<SceneSelectorScript>().ToggleInteract();

    }
}
