using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour, IDropHandler
{
    public int ChildCount;
    // Start is called before the first frame update
    void Start()
    {
        ChildCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        ChildCount = transform.childCount;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null)
        {
            if (transform.childCount == 0)
            {

                GameObject dropped = eventData.pointerDrag;
                PotionScript Potion = dropped.GetComponent<PotionScript>();
                Potion.ParentAfterDrag = transform;
                this.gameObject.GetComponent<Image>().raycastTarget = false;
            }

        }
        

    }

}
