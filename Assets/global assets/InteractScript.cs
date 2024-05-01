using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    private bool InArea = false;
    private int recorded_actions = 0;
    [SerializeField] int actions = 3;
    [SerializeField] GameObject drop;
    [SerializeField] int random_max = 3;
    

    void Update()
    {
        if (InArea ==  true && Input.GetKeyDown(KeyCode.E))
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
        if (recorded_actions == actions)
        {
            int x = Random.Range(1, random_max);
            for (int i = 0; i < x; i++)
            {
                float posx = this.gameObject.transform.position.x + Random.Range(-2f, 2f);
                float posy = this.gameObject.transform.position.y + Random.Range(-2f, 2f);

                GameObject element = Instantiate(drop);
                element.transform.position = new Vector3(posx, posy, -1);
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Hit!");
            recorded_actions++;
        }
        
    }
}
