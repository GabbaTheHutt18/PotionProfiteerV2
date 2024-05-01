using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ItemSlotPrefab;
    [SerializeField] private GameObject DropBoxPointer;
    [SerializeField] private int slot_num;
    [SerializeField] private bool horizontal = false;
    public bool activate = true;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slot_num; i++)
        {
            GameObject newslot = Instantiate(ItemSlotPrefab, this.transform);
            newslot.transform.GetChild(0).GetComponent<ItemSlotScript>().DropBoxRef = DropBoxPointer;
            newslot.transform.GetChild(0).GetComponent<ItemSlotScript>().activedrop = activate;
            newslot.transform.GetChild(0).GetComponent<Image>().raycastTarget = activate;
        }

        if (horizontal == false)
        {
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.7441f, (slot_num / 10f));
        }
        else if (horizontal == true)
        {
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(2.2f, 1f);
        }
        
    }
}
