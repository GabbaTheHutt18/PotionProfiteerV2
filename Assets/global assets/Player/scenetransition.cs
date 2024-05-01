using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenetransition : MonoBehaviour
{
    [SerializeField] private int SceneIndexValue;
    private bool InArea = false;

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
        SceneManager.LoadScene(SceneIndexValue);

    }
}
