using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WagonManager : MonoBehaviour
{
    private bool InArea = false;
    private bool visible = false;
    [SerializeField] private AnimationClip anim_in;
    [SerializeField] private AnimationClip anim_out;
    [HideInInspector] GameObject gridElem;
    [HideInInspector] MainManagerScript mainManager;
    [HideInInspector] private InventoryManager HandBag_Ref;
    private PlayerScript playerScript;
    private HandBag_DropBox DropBox;
    

    private void Start()
    {
        gridElem = transform.GetChild(0).GetChild(0).gameObject;
        mainManager = GameObject.FindWithTag("Manager").GetComponent<MainManagerScript>();
        HandBag_Ref = GameObject.Find("HB_Inventory").GetComponent<InventoryManager>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        DropBox = GameObject.Find("DropBox").GetComponent<HandBag_DropBox>();
    }

    void Update()
    {
        if (InArea == true && Input.GetKeyDown(KeyCode.E))
        {
            Interaction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InArea = false;
        }
    }

    void Interaction()
    {

        if (visible == false)
        {
            //gridElem.GetComponent<RectTransform>().localPosition = new Vector3(216f, -4f, 0f);
            gridElem.GetComponent<Animation>().clip = anim_in;
            gridElem.GetComponent<Animation>().Play();

            HandBag_Ref.ToggleInventoryVisibility();
            visible = true;
            playerScript.moveSpeed = 0;
            DropBox.Main = 1;
        }
        else if (visible == true)
        {
            //gridElem.GetComponent<RectTransform>().localPosition = new Vector3(216f, 1040f, 0f);
            gridElem.GetComponent<Animation>().clip = anim_out;
            gridElem.GetComponent<Animation>().Play();

            HandBag_Ref.ToggleInventoryVisibility();
            visible = false;
            playerScript.moveSpeed = 5;
            DropBox.Main = 0;
        }
    }

    public void Transfer(GameObject item)
    {
        int childnum = gridElem.transform.childCount;
        
        GameObject gridspace = gridElem.transform.GetChild(0).GetChild(0).gameObject; // Starts at the first child
        for (int i = 0; i < childnum; i++) //Runs through the children to find the next one that's empty (using a bool inicator on the shildren)
        {
            Transform reference = gridElem.transform.GetChild(i).GetChild(0);
            if (reference.GetComponent<ItemSlotScript>().empty == true)
            {
                gridspace = reference.transform.gameObject;
                i = childnum; // ends loop early when an empty slot is found
            }

        }
        gridspace.GetComponent<ItemSlotScript>().Set(item); // allocates item to selected grid slot
        
    }

    public void ItemConversion() 
    {
        int childnum = gridElem.transform.childCount;
        GameObject gridspace = gridElem.transform.GetChild(0).GetChild(0).gameObject; // Starts at the first child
        for (int i = 0; i < childnum; i++) //Runs through the children to find the next one that's empty (using a bool inicator on the shildren)
        {
            Transform reference = gridElem.transform.GetChild(i).GetChild(0);
            if (reference.GetComponent<ItemSlotScript>().empty == false)
            {
                string objectID = reference.GetComponent<ItemSlotScript>().ID;
                mainManager.ResourceInventory[objectID] += 1;

            }

        }
    }

    private void OnDestroy()
    {
        ItemConversion();
    }
}
