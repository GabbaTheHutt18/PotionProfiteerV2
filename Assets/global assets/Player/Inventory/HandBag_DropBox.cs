using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandBag_DropBox : MonoBehaviour, IDropHandler
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] public int Main = 0;
    private int counter;
    public void OnDrop(PointerEventData eventData) {

        ItemSlotScript droppedItem = eventData.pointerDrag.GetComponent<ItemSlotScript>();
        GameObject itemref = droppedItem.referenceObj;


        if (Main == 0) 
        {
            if (itemref != null)
            {
                inventoryManager.RemoveItem(itemref, transform.root.parent, true);
                droppedItem.Reset();
                Debug.Log("Item Dropped!");
            }
            else
            {
                Debug.Log("twat");
            }
        }
        
        if (Main == 1) 
        {
            WagonManager wagonManager = GameObject.Find("TriggerBox-A").GetComponent<WagonManager>();
            if (itemref != null && counter <= 15)
            {
                inventoryManager.RemoveItem(itemref, GameObject.Find("TriggerBox-A").transform, false);
                wagonManager.Transfer(itemref);
                droppedItem.Reset();
                counter++;
                
            }
            else
            {
                Debug.Log("Wagon is Full!");
            }
        }
    }
}
