using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour
{

    public Transform pointer;
    public bool sliderCanMove;
    public MainManagerScript MainManager;
    public CircleCollider2D circleCollider;
    public bool canMove;

    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        sliderCanMove = false;
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointer.transform.position)
        {
            // Debug.Log("Pos match");
            sliderCanMove = false;
            circleCollider.enabled = true;
        }

        if (canMove)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, pointer.position, 0.002f);
        }
    }

    public void AddPotion(int PotionID)
    {
        Vector2 Potion = pointer.transform.position;
        MainManager.Potions.Add(new Potion(Potion, PotionID));
    }

    public void PotionConfirmed()
    {
        if (transform.position != pointer.transform.position)
        {
            sliderCanMove = true;
            circleCollider.enabled = false;
        }
    }
}
