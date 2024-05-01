using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public GameObject pointer;
    private Vector3 addToPos;
    private bool hasAdded;
    public float multiplier = 0f;
    public MainManagerScript MainManager;
    public bool isValidPress = false;

    public void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        //pointer = GameObject.Find("Pointer");
        hasAdded = false;
    }

    public void Update()
    {
        Movement move = pointer.GetComponent<Movement>();
        if (!hasAdded)
        {  
            move.currentPos += addToPos;
            hasAdded = true;
        }      
    }

    public void SetPlant()
    { 
        multiplier = 0.4f;
    }

    public void SetMineral()
    { 
        multiplier = 0.8f;
    }

    public void SetLiquid() 
    {
        multiplier = 1.2f;
    }

    public void SetAnimal()
    {
        multiplier = 1.5f;
    }
        


    public void Right()
    {
        switch (multiplier)
        {
            case 0.4f:
                if (MainManager.ResourceInventory["firePlant"] != 0)
                {
                    MainManager.ResourceInventory["firePlant"] -= 1;
                    isValidPress = true;
                }
                break;
            case 0.8f:
                if (MainManager.ResourceInventory["fireMineral"] != 0)
                {
                    MainManager.ResourceInventory["fireMineral"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.2f:
                if (MainManager.ResourceInventory["fireLiquid"] != 0)
                {
                    MainManager.ResourceInventory["fireLiquid"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.5f:
                if (MainManager.ResourceInventory["fireAnimal"] != 0)
                {
                    MainManager.ResourceInventory["fireAnimal"] -= 1;
                    isValidPress = true;
                }
                break;
            default:
                break;
        }
        if (isValidPress)
        {
            addToPos = new Vector3(multiplier, 0, 0);
            hasAdded = false;
            isValidPress = false;
        }
        
    }

    public void Left()
    {
        switch (multiplier)
        {
            case 0.4f:
                if (MainManager.ResourceInventory["icePlant"] != 0)
                {
                    MainManager.ResourceInventory["icePlant"] -= 1;
                    isValidPress = true;
                }
                break;
            case 0.8f:
                if (MainManager.ResourceInventory["iceMineral"] != 0)
                {
                    MainManager.ResourceInventory["iceMineral"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.2f:
                if (MainManager.ResourceInventory["iceLiquid"] != 0)
                {
                    MainManager.ResourceInventory["iceLiquid"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.5f:
                if (MainManager.ResourceInventory["iceAnimal"] != 0)
                {
                    MainManager.ResourceInventory["iceAnimal"] -= 1;
                    isValidPress = true;
                }
                break;
            default:
                break;
        }
        if (isValidPress)
        {
            addToPos = new Vector3(-(multiplier), 0, 0);
            hasAdded = false;
            isValidPress = false;
        }
        
    }

    public void Up()
    {
        switch (multiplier)
        {
            case 0.4f:
                if (MainManager.ResourceInventory["herbPlant"] != 0)
                {
                    MainManager.ResourceInventory["herbPlant"] -= 1;
                    isValidPress = true;
                }
                break;
            case 0.8f:
                if (MainManager.ResourceInventory["herbMineral"] != 0)
                {
                    MainManager.ResourceInventory["herbMineral"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.2f:
                Debug.Log(MainManager.ResourceInventory["herbLiquid"]);
                if (MainManager.ResourceInventory["herbLiquid"] != 0)
                {
                    MainManager.ResourceInventory["herbLiquid"] -= 1;
                    isValidPress = true;
                    Debug.Log(MainManager.ResourceInventory["herbLiquid"]);
                }
                break;
            case 1.5f:
                if (MainManager.ResourceInventory["herbAnimal"] != 0)
                {
                    MainManager.ResourceInventory["herbAnimal"] -= 1;
                    isValidPress = true;
                }
                break;
            default:
                break;
        }
        if (isValidPress)
        {
            addToPos = new Vector3(0, multiplier, 0);
            hasAdded = false;
            isValidPress = false;
        }

    }

    public void Down()
    {
        switch (multiplier)
        {
            case 0.4f:
                if (MainManager.ResourceInventory["cavePlant"] != 0)
                {
                    MainManager.ResourceInventory["cavePlant"] -= 1;
                    isValidPress = true;
                }
                break;
            case 0.8f:
                if (MainManager.ResourceInventory["caveMineral"] != 0)
                {
                    MainManager.ResourceInventory["caveMineral"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.2f:
                if (MainManager.ResourceInventory["caveLiquid"] != 0)
                {
                    MainManager.ResourceInventory["caveLiquid"] -= 1;
                    isValidPress = true;
                }
                break;
            case 1.5f:
                if (MainManager.ResourceInventory["caveAnimal"] != 0)
                {
                    MainManager.ResourceInventory["caveAnimal"] -= 1;
                    isValidPress = true;
                }
                break;
            default:
                break;
        }
        if (isValidPress)
        {
            addToPos = new Vector3(0, -(multiplier), 0);
            hasAdded = false;
            isValidPress = false;
        }
        
    }

    public void DUR()
    {
        addToPos = new Vector3(1, 1, 0);
        hasAdded = false;
    }

    public void DUL()
    {
        addToPos = new Vector3(-1, 1, 0);
        hasAdded = false;
    }

    public void DDR()
    {
        addToPos = new Vector3(1, -1, 0);
        hasAdded = false;
    }

    public void DDL()
    {
        addToPos = new Vector3(-1, -1, 0);
        hasAdded = false;
    }

}
