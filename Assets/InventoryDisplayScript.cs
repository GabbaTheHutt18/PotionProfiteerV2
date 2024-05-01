using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplayScript : MonoBehaviour
{

    MainManagerScript MainManager;
    public TMP_Text firePlant;
    public TMP_Text herbPlant;
    public TMP_Text icePlant;
    public TMP_Text cavePlant;
    public TMP_Text fireSeed;
    public TMP_Text herbSeed;
    public TMP_Text iceSeed;
    public TMP_Text caveSeed;
    public TMP_Text fireLiquid;
    public TMP_Text herbLiquid;
    public TMP_Text iceLiquid;
    public TMP_Text caveLiquid;
    public TMP_Text fireMineral;
    public TMP_Text herbMineral;
    public TMP_Text iceMineral;
    public TMP_Text caveMineral;
    public TMP_Text fireAnimal;
    public TMP_Text herbAnimal;
    public TMP_Text iceAnimal;
    public TMP_Text caveAnimal;
    public TMP_Text potion1;
    public TMP_Text potion2;
    public TMP_Text potion3;
    public TMP_Text potion4;
    // Start is called before the first frame update
    void Start()
    {
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        firePlant.text = MainManager.ResourceInventory["firePlant"].ToString();
        herbPlant.text = MainManager.ResourceInventory["herbPlant"].ToString();
        icePlant.text = MainManager.ResourceInventory["icePlant"].ToString();
        cavePlant.text = MainManager.ResourceInventory["cavePlant"].ToString();
        fireSeed.text = MainManager.ResourceInventory["fireSeeds"].ToString();
        herbSeed.text = MainManager.ResourceInventory["herbSeeds"].ToString();
        iceSeed.text = MainManager.ResourceInventory["iceSeeds"].ToString();
        caveSeed.text = MainManager.ResourceInventory["caveSeeds"].ToString();
        fireLiquid.text = MainManager.ResourceInventory["fireLiquid"].ToString();
        herbLiquid.text = MainManager.ResourceInventory["herbLiquid"].ToString();
        iceLiquid.text = MainManager.ResourceInventory["iceLiquid"].ToString();
        caveLiquid.text = MainManager.ResourceInventory["caveLiquid"].ToString();
        fireMineral.text = MainManager.ResourceInventory["fireMineral"].ToString();
        herbMineral.text = MainManager.ResourceInventory["herbMineral"].ToString();
        iceMineral.text = MainManager.ResourceInventory["iceMineral"].ToString();
        caveMineral.text = MainManager.ResourceInventory["caveMineral"].ToString();
        fireAnimal.text = MainManager.ResourceInventory["fireAnimal"].ToString();
        herbAnimal.text = MainManager.ResourceInventory["herbAnimal"].ToString();
        iceAnimal.text = MainManager.ResourceInventory["iceAnimal"].ToString();
        caveAnimal.text = MainManager.ResourceInventory["caveAnimal"].ToString();

        int numPotion1 = 0;
        int numPotion2 = 0;
        int numPotion3 = 0;
        int numPotion4 = 0;
        foreach (var item in MainManager.Potions)
        {
            switch (item.ID)
            {
                case 0:
                    numPotion1++;

                    break;
                case 1:
                    numPotion2++;

                    break;
                case 2:
                    numPotion3++;

                    break;
                case 3:
                    numPotion4++;

                    break;
                default:
                    break;
            }
        }
        potion1.text = numPotion1.ToString();
        potion2.text = numPotion2.ToString(); 
        potion3.text = numPotion3.ToString(); 
        potion4.text = numPotion4.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
