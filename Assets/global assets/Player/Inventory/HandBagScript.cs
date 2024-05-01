using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HandBagScript : MonoBehaviour
{
    //Variables
    private int resInArea = 0; // number of resources within the area that the player can grab
    [SerializeField] List<GameObject> grabable = new List<GameObject>(); // List of objects in grabbale area
    public int HandBagLimit = 10; // Max amount of items that can be held at once
    GameObject InvManager;

    void Start()
    {
        InvManager = GameObject.Find("HB_Inventory"); // reference to the Inventory manager
    }
    

    void Update()
    {

        if (resInArea != 0 && Input.GetKeyDown(KeyCode.E))
        {
            if (this.gameObject.transform.childCount < HandBagLimit) 
            {
                GameObject chosenElem = grabable[0]; //gets item that first entered the area (index 0 in list)
                GameObject itemRef = chosenElem.gameObject;
                InvManager.GetComponent<InventoryManager>().AddItem(itemRef); // passes object reference to Inventory Manager
                chosenElem.transform.SetParent(this.gameObject.transform); // Sets parent to HandBag (Parent of Player)
                chosenElem.gameObject.SetActive(false); 
                grabable.Remove(chosenElem); // Deactivates object and removes it from grabale list
            }
            else
            {
                Debug.Log("HandBag is full!"); // Prints if handbag limit is reached
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // adds each item that enters to the list in order of which they entered. update resInArea
    {
        if (collision.tag == "Collectable")
        {
            grabable.Add(collision.gameObject);
            resInArea++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // removes item from the list when it leaves the area. updates resInArea
    {
        if (collision.tag == "Collectable")
        {
            grabable.Remove(collision.gameObject);
            resInArea--;
        }
    }
}
