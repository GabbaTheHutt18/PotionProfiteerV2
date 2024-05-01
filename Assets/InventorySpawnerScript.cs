using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpawnerScript : MonoBehaviour
{
    public GameObject InventorySlot;
    LogicManagerScript LogicManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        foreach (var item in LogicManager.Potions)
        {
            SpawnPotion(item);
        }
    }

    public void CloseInventory()
    {
       int numberOfChildren = this.gameObject.transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
        }
    
    }

    public void SpawnPotion(Potion PotionType)
    {

        GameObject Potion = Instantiate(InventorySlot, transform.position, transform.rotation, this.gameObject.transform);
        Potion.transform.GetChild(0).GetComponent<PotionScript>()._Potion = PotionType;
        //Potion.transform.GetChild(0).GetComponent<PotionScript>().image.sprite = PotionType.PotionSprite;

    }
}
