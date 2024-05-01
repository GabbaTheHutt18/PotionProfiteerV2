using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class PlantSlotScript : MonoBehaviour, IDropHandler
{
    MainManagerScript mainManagerScript;
    public int PlantType;
    public GameObject Plant;
    public Sprite Seeds; 
    // Start is called before the first frame update
    void Start()
    {
        mainManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        switch (PlantType)
        {
            case 0:
                if (mainManagerScript.ResourceInventory["firePlant"]  >= 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 1:
                if (mainManagerScript.ResourceInventory["herbPlant"] >= 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 2:
                if (mainManagerScript.ResourceInventory["icePlant"] >= 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 3:
                if (mainManagerScript.ResourceInventory["cavePlant"] >= 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            default:
                break;
        }
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        
    }

    public void SpawnPlants()
    {
        GameObject _plant = Instantiate(Plant, this.transform);
        _plant.GetComponent<PlantScript>().PlantType = PlantType;
        _plant.GetComponent<PlantScript>().Assign();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            GameObject dropped = eventData.pointerDrag;
            PlantScript Plant = dropped.GetComponent<PlantScript>();
            Plant.ParentAfterDrag = transform;
            Debug.Log(Plant.PlantType);
            Debug.Log(mainManagerScript.ResourceInventory["herbPlant"]);
            switch (Plant.PlantType)
            {
                case 0:
                    mainManagerScript.ResourceInventory["firePlant"] += 1;
                    break;
                case 1:
                    mainManagerScript.ResourceInventory["herbPlant"] += 1;
                    Debug.Log(mainManagerScript.ResourceInventory["herbPlant"]);
                    break;
                case 2:
                    mainManagerScript.ResourceInventory["icePlant"] += 1;
                    break;
                case 3:
                    mainManagerScript.ResourceInventory["cavePLant"] += 1;
                    break;
                default:
                    break;
            }



        }


    }
}
