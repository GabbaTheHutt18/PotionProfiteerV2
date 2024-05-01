using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour
{
    [HideInInspector] public bool BoxBorderLeft = false; // Used to detect left side movement
    [HideInInspector] public bool BoxBorderRight = false; // Used to detect right side movement
    [HideInInspector] public bool BoxBorderUp = false; // Used to detect top side movement
    [HideInInspector] public bool BoxBorderDown = false; // Used to detect bottom side movement
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player").gameObject; // Gets reference to player
    }


    void FixedUpdate() // Checks for each of the 4 bool triggers and moves camera accordingly
    {
        if (BoxBorderLeft == true)
        {
            transform.position += new Vector3(-1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0, 0);
        }
        
        if (BoxBorderRight == true)
        {
            transform.position += new Vector3(1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0, 0);
        }
        
        if (BoxBorderUp == true) 
        {
            transform.position += new Vector3(0, 1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0);
        }
        
        if (BoxBorderDown == true) 
        {
            transform.position += new Vector3(0, -1 * player.GetComponent<PlayerScript>().moveSpeed * Time.deltaTime, 0);
        }
        
    }
}
