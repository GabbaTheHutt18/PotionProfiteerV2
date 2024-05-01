using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoardManagerScript : MonoBehaviour
{
    public Button Quest;
    public MainManagerScript MainManager;
    public TMP_Text QuestTitle;
    public TMP_Text QuestDescription;
    public TMP_Text QuestRequirements;
    public TMP_Text QuestReward;
    public TMP_Text ErrorMessage;
    public Quest ChosenQuest;
    public bool completedQuest = false;

    // Start is called before the first frame update
    void Start()
    {
       
        MainManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainManagerScript>();
        foreach (var item in MainManager.Quests)
        {
            Button newQuest = Instantiate(Quest,this.transform);
            newQuest.GetComponent<QuestScript>().QuestData = item;
            newQuest.GetComponent<QuestScript>().QuestTitle = QuestTitle;
            newQuest.GetComponent<QuestScript>().QuestRequirements = QuestRequirements;
            newQuest.GetComponent<QuestScript>().QuestReward = QuestReward;
            
            newQuest.transform.GetChild(0).GetComponent<TMP_Text>().text = item.QuestTitle;
     

        }
    }


    public void CompleteQuest()
    {
        List<Potion> RemovePotions = new List<Potion>();
        if (completedQuest && ChosenQuest.QuestCompleted != true)
        {
            foreach (var item in ChosenQuest.ResourceRequirements)
            {
                if (MainManager.ResourceInventory[item.Key] == item.Value)
                {
                    MainManager.ResourceInventory[item.Key] -= item.Value;
                }
            }
            
            foreach (var item in ChosenQuest.PotionRequirements)
            {
                foreach (var Potion in MainManager.Potions)
                {
                    if (Potion.ID == item.ID)
                    {
                        RemovePotions.Add(Potion);
                    }
                }
            }
            foreach(var item in RemovePotions)
            {
                MainManager.Potions.Remove(item);
            }
            
            ChosenQuest.QuestCompleted = true;
            if (ChosenQuest.RewardType == 0)
            {
                MainManager.Coin += ChosenQuest.CoinReward;
            }
            else
            {
                foreach (var item in ChosenQuest.ResourceReward)
                {
                    MainManager.ResourceInventory[item.Key] += item.Value;
                }
            }

        }
        else
        {
            ErrorMessage.gameObject.SetActive(true);
            //enabled = false; -> can't used .enabled on TMP
        }

        
    }

    public void SelectedQuest(Quest _questData)
    {
        ErrorMessage.gameObject.SetActive(false);
        completedQuest = false;
        int num = -1;
        completedQuest = false;
        if (_questData.ResourceRequirements.Count != 0)
        {
            num = _questData.ResourceRequirements.Count;
            foreach (var item in _questData.ResourceRequirements)
            {
                if (MainManager.ResourceInventory[item.Key] == item.Value)
                {
                    num -= 1;
                }
            }
        }
        else
        {
            num = _questData.PotionRequirements.Count;
            foreach (var item in _questData.PotionRequirements)
            {
                foreach (var Potion in MainManager.Potions)
                {
                    if (Potion.ID == item.ID)
                    {
                        num -= 1;
                    }
                }
            }
        }

        ChosenQuest = _questData;
        if (num == 0)
        {
            completedQuest = true;
        }

    }
}
