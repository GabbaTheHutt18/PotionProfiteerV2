using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionBrewed : MonoBehaviour
{
    public int PotionID;
    public bool IspotionBrewed;
    public Sprite Potion1;
    public Sprite Potion2;
    public Sprite Potion3;
    public Sprite Potion4;
    public SpriteRenderer PotionSprite; 

    // Start is called before the first frame update
    void Start()
    {
        IspotionBrewed = false;
        switch (PotionID)
        {
            case 0:
                PotionSprite.sprite = Potion1;
                break;
            case 1:
                PotionSprite.sprite = Potion2;
                break;
            case 2:
                PotionSprite.sprite = Potion3;
                break;
           case 3:
                PotionSprite.sprite = Potion4;
                break;
            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Follower")
        {
            IspotionBrewed = true;
            other.gameObject.GetComponent<FollowPointer>().AddPotion(PotionID);
        }
    }
}
