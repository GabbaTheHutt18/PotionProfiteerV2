using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC_Script : MonoBehaviour
{
    public int hatedPotion;
    public int favouritePotion;
    public SpriteRenderer SpriteRender;
    public Sprite Character1;
    public Sprite Character2;
    public List<List<string>> Dialogue = new List<List<string>> { new List<string> { "Sure", "Ew no I don't want to pay for it anymore", "No, I only want to pay this please :)", "Give me something I want to buy!", "No I don't want anything anymore :/", "Sure", "Wow, my Fav!", "Ew..."},
    new List<string> { "Yeah I'll pay that!", "Oh no thank you, I don't want to pay for this", "I'll only pay this please :)", "What did you want me to buy?", "I've changed my mind, I don't want to buy anything now :/", "Mmm its Ok", "Yay!", "Oh I hate this"},
    new List<string> { "Yes please!", "Ew not for that price", "Nah I'm not paying anymore than this :)", "Give me something to buy", "Nah I'm good, I'm not buying anything now... :/", "It ok", "You made my favourite!", "This is not great..."}};
    public List<string> SelectedDialogue = new List<string>(); 

    // Start is called before the first frame update
    void Start()
    {
        hatedPotion = Random.Range(0, 4);
        favouritePotion = Random.Range(0,4);
        int DialogueOption = Random.Range(0, Dialogue.Count);
        SelectedDialogue = new List<string>(Dialogue[DialogueOption]);
        int randomint = Random.Range(0, 2);
        switch (randomint)
        {
            case 0:
                SpriteRender.sprite = Character1;
                break;
            case 1:
                SpriteRender.sprite = Character2;
                break;
            default:
            break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
