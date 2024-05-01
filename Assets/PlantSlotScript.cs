using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
                if (mainManagerScript.ResourceInventory["firePlant"]  > 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 1:
                if (mainManagerScript.ResourceInventory["herbPlant"] > 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 2:
                if (mainManagerScript.ResourceInventory["icePlant"] > 1 && transform.childCount < 1)
                {
                    SpawnPlants();
                }
                break;
            case 3:
                if (mainManagerScript.ResourceInventory["cavePlant"] > 1 && transform.childCount < 1)
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
            if (transform.childCount == 0)
            {

                GameObject dropped = eventData.pointerDrag;
                PotionScript Plant = dropped.GetComponent<PotionScript>();
                Plant.ParentAfterDrag = transform;
            }
            


        }


    }
}
