using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FailedPotionPopUp : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
        
    }



    public void ClosePopUp()
    {
        Destroy(gameObject);

    }
}
