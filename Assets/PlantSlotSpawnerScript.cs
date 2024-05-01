using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSlotSpawnerScript : MonoBehaviour
{
    public GameObject PlantSlot;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) 
        {
            GameObject slot = Instantiate(PlantSlot, transform);
            slot.GetComponent<PlantSlotScript>().PlantType = i; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
