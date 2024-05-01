using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBoxScript : MonoBehaviour, IDropHandler
{
    GameObject dropped = null;
    PotionScript DragDrop;
    LogicManagerScript LogicManager;
    // Start is called before the first frame update
    void Start()
    {
        LogicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {

            dropped = eventData.pointerDrag;
            DragDrop = dropped.GetComponent<PotionScript>();
            DragDrop.ParentAfterDrag = transform;
        }

    }

    public void InventoryClosed()
    {
        if (transform.childCount > 0)
        {
            LogicManager.SelectedPotion = gameObject.transform.GetChild(0).GetComponent<PotionScript>()._Potion;
            DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
        }
        
    }

}
