using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LogicManagerScript : MonoBehaviour
{
    public List<Potion> Potions = new List<Potion>();
    public GameObject NPC;
    NPC_Script NPC_Script;
    bool WantToBarter = true;
    public int Price = 0;
    public int Coin = 0;
    public Potion SelectedPotion;
    public TMP_Text Offer;
    public TMP_Text Dialog;
    public TMP_Text CoinText;
    MainManagerScript mainManagerScript;
    // Start is called before the first frame update
    void Awake()
    {
        Vector3 position = new Vector3(0, 1.65f, -2);
        GameObject _npc = Instantiate(NPC, position, transform.rotation);
        NPC_Script = _npc.GetComponent<NPC_Script>();
        mainManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        Potions = mainManagerScript.Potions;
        CoinText.text = "Coin: " + Coin;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPrice()
    {
        if (SelectedPotion == null)
        {
            Dialog.text = "You've not given me anything to buy??";

        }
        else
        {
            Price = (int)(Mathf.Abs(SelectedPotion.PotionStats.x*10) + Mathf.Abs(SelectedPotion.PotionStats.y * 10));
            if (NPC_Script.hatedPotion == SelectedPotion.ID)
            {
                Price = (int)(Price * 0.5);

                Dialog.text = NPC_Script.SelectedDialogue[7];

            }
            else if (NPC_Script.favouritePotion == SelectedPotion.ID)
            {
                Price *= 2;
                Dialog.text = NPC_Script.SelectedDialogue[6];
            }
            else
            {
                Dialog.text = NPC_Script.SelectedDialogue[5];
            }
        }
       
        Offer.text = "Price: " + Price;
        
    }

    public void Sold() {
        Coin += Price;
        mainManagerScript.Coin += Price;
        Potions.Remove(SelectedPotion);
        CoinText.text = "Coin: " + Coin;
        Price = 0;
        Offer.text = "Price: " + Price;
        Dialog.text = "Cheers!";
        WantToBarter = true;
    }

    public void Reject()
    {
        Debug.Log("Go Back to Shop");
    }

    public void Barter()
    {
        if (WantToBarter)
        {
            if (Price != 0) {
                int RandomInt = Random.Range(1, 10);
                if (RandomInt % 2 == 0)
                {
                    Dialog.text = NPC_Script.SelectedDialogue[0];
                    float multiplier = Price / 100;
                    int PriceIncrease = (int)(multiplier * Random.Range(10, 101));
                    Price += Price + PriceIncrease;
                    WantToBarter = true;
                }
                else if (RandomInt == 7)
                {
                    Dialog.text = NPC_Script.SelectedDialogue[1];
                    Price = 0;
                    WantToBarter = false;
                }
                else
                {
                    Dialog.text = NPC_Script.SelectedDialogue[2];
                    WantToBarter = false;
                }
            }
            else
            {
                Dialog.text = NPC_Script.SelectedDialogue[3];
            }
            
        }
        else
        {
            Dialog.text = NPC_Script.SelectedDialogue[4];
            Price = 0;
        }

        Offer.text = "Price: " + Price;

    }
}
