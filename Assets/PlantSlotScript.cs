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
        string Plant = "";
        switch (PlantType)
        {
            case 0:
                if (mainManagerScript.ResourceInventory["firePlant"] > transform.childCount && transform.childCount < 1)
                {
                    SpawnPlants();
                    
                }
                Plant = "firePlant";
                break;
            case 1:
                if (mainManagerScript.ResourceInventory["herbPlant"] > transform.childCount && transform.childCount < 1)
                {
                    SpawnPlants();
                    
                }
                Plant = "herbPlant";
                
                break;
            case 2:
                if (mainManagerScript.ResourceInventory["icePlant"] > transform.childCount && transform.childCount < 1)
                {
                    SpawnPlants();
                    Plant = "icePlant";
                }
                Plant = "icePlant";
                break;
            case 3:
                if (mainManagerScript.ResourceInventory["cavePlant"] > transform.childCount && transform.childCount < 1)
                {
                    SpawnPlants();
                    

                }
                Plant = "cavePlant";
                break;
            default:
                break;
        }
        if (transform.childCount > 1 || transform.childCount > mainManagerScript.ResourceInventory[Plant])
        {
            Destroy(transform.GetChild(0).gameObject);
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

        }


    }
}
