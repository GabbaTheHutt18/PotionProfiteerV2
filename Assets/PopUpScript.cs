using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpScript : MonoBehaviour
{
    public TMP_Text PopUpText;
    int id;
    public MainManagerScript MainManager;
    // Start is called before the first frame update
    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        if (MainManager.BlewUp)
        {
            id = -1;
            PopUpText.text = "Silly, you've gassed yourself xxx";
        }
        else
        {
            id = Random.Range(1, 5);
            switch (id)
            {
                case 1:
                    PopUpText.text = "You've been mugged!";
                    break;
                case 2:
                    PopUpText.text = "mmm snack";
                    break;
                case 3:
                    PopUpText.text = "slag";
                    break;
                case 4:
                    PopUpText.text = "No";
                    break;
                default:
                    break;

            }
        } 
        
        
    }

 

    public void ClosePopUp()
    {
        switch (id)
        {
            case 1:
                if (MainManager.Coin >= 5)
                {
                    MainManager.Coin -= 5;
                }
                else
                {
                    MainManager.Coin = 0;
                }

                break;
            case 2:
                if (MainManager.ResourceInventory["herbPlant"] >= 2)
                {
                    MainManager.ResourceInventory["herbPlant"] -= 2;
                }
                else
                {
                    MainManager.ResourceInventory["herbPlant"] = 0;
                }

                break;
            case 3:
                if (MainManager.ResourceInventory["fireMineral"] >= 2)
                {
                    MainManager.ResourceInventory["fireMineral"] -= 2;
                }
                else
                {
                    MainManager.ResourceInventory["fireMineral"] = 0;
                }

                break;
            case 4:
                if (MainManager.ResourceInventory["iceLiquid"] >= 3)
                {
                    MainManager.ResourceInventory["iceLiquid"] -= 3;
                }
                else
                {
                    MainManager.ResourceInventory["iceLiquid"] = 0;
                }
                

                break;
            default:
                break;

        }

        if (MainManager.BlewUp)
        {
            MainManager.BlewUp = false;
        }
        Destroy(gameObject);

    }
}
