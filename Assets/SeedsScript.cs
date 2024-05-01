using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedsScript : MonoBehaviour
{
    HerbLogicManager herbLogicManager;
    public int PlantType;
    public Image Image;
    public Sprite SeedsSprite;
    public Sprite PlantSprite;
    public Sprite FireSeeds;
    public Sprite HerbSeeds;
    public Sprite IceSeeds;
    public Sprite CaveSeeds;
    public Sprite FirePlant;
    public Sprite HerbPlant;
    public Sprite IcePlant;
    public Sprite CavePlant;
    public int Planter;
    // Start is called before the first frame update
    void Start()
    {
        herbLogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<HerbLogicManager>();
        Debug.Log(Planter);
        switch (PlantType)
        {
            case 0:
                SeedsSprite = FireSeeds;
                PlantSprite = FirePlant;
                break;
            case 1:
                SeedsSprite = HerbSeeds;
                PlantSprite = HerbPlant;
                break;
            case 2:
                SeedsSprite=IceSeeds;  
                PlantSprite = IcePlant;
                break;
            case 3:
                SeedsSprite=CaveSeeds;
                PlantSprite = CavePlant;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (herbLogicManager.explored)
        {
            Image.sprite = PlantSprite;
        }
        else
        {
            Image.sprite = SeedsSprite;
        }
    }

    public void OnClicked()
    { 
        if(herbLogicManager.explored)
        {
            switch (PlantType)
            {
                case 0:
                    herbLogicManager.mainManagerScript.ResourceInventory["firePlant"] += 3;

                    break;
                case 1:
                    herbLogicManager.mainManagerScript.ResourceInventory["herbPlant"] += 3;

                    break;
                case 2:
                    herbLogicManager.mainManagerScript.ResourceInventory["icePlant"] += 3;
 
                    break;
                case 3:
                    herbLogicManager.mainManagerScript.ResourceInventory["cavePlant"] += 3;
   
                    break;
                default:
                    break;
            }
        }
        Debug.Log(Planter);
        herbLogicManager.mainManagerScript.PlantedSeeds[Planter] = -1;
        Debug.Log(herbLogicManager.mainManagerScript.PlantedSeeds.Count);
        Destroy(gameObject);
    }
}
