using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Transform ParentAfterDrag;
    public Image image;
    public Potion _Potion;
    public TMP_Text text;
    public Vector2 PotionType;
    public int potionID;
    public Sprite Potion1;
    public Sprite Potion2;
    public Sprite Potion3;
    public Sprite Potion4;
    // Start is called before the first frame update
    void Start()
    {
        PotionType = _Potion.PotionStats;
        potionID = _Potion.ID;
        text.text = PotionType.ToString();
        switch (potionID)
        {
            case 0:
                image.sprite = Potion1;
                break;
            case 1:
                image.sprite = Potion2;
                break;
            case 2:
                image.sprite = Potion3;
                break;
            case 3:
                image.sprite = Potion4;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        text.raycastTarget = false;
        text.gameObject.SetActive(false);
        //text.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        image.raycastTarget = true;
        text.raycastTarget = true;
        text.gameObject.SetActive(true);
    }
}
