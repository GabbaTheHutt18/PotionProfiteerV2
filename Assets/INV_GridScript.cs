using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class INV_GridScript : MonoBehaviour, IDropHandler
{
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (transform.childCount == 0)
            {

                GameObject dropped = eventData.pointerDrag;
                ItemSlotScript ItemSlot = dropped.GetComponent<ItemSlotScript>();
                ItemSlot.ParentAfterDrag = transform;
            }

        }
        Debug.Log("fuck");


    }
   
}
