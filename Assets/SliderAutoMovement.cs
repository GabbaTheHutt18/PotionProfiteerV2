using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderAutoMovement : MonoBehaviour
{
    private GameObject Follower;
    public Slider slider;
    [SerializeField] float slideSpeed = 0.1f;
    private bool forwards;
    public bool shouldPress;
    private FollowPointer FP;

    // Start is called before the first frame update
    void Start()
    {
        Follower = GameObject.Find("Follower");
        forwards = true;
        slider.value = 0;
        shouldPress = false;
        FP = Follower.GetComponent<FollowPointer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0.25 && slider.value < 0.75)
        {
            shouldPress = true;
        }
        else
        {
            shouldPress = false;
        }
        
        if (FP.sliderCanMove == true)
        {
            if (forwards)
            {
                slider.value += slideSpeed * Time.deltaTime;
            }
            else
            {
                slider.value -= slideSpeed * Time.deltaTime;
                if (slider.value == 0)
                {
                    forwards = true;
                }
            }

            if (slider.value == 1)
            {
                forwards = false;
            }
        }
        if (FP.sliderCanMove == false)
        {
            slider.value = 0;
        }
       
    }

    public void ButtonPressed()
    {
        if (shouldPress)
        {
            FP.canMove = true;
            FP.sliderCanMove = false;
        }
        else
        {
            MainManagerScript mainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
            mainManager.BlewUp = true;
            mainManager.GoBackToShop();
        }
    }
}
