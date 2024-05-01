using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectorScript : MonoBehaviour
{
    CanvasGroup _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = gameObject.GetComponent<CanvasGroup>();
        ToggleInteract();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrassButtonPress()
    {
        SceneManager.LoadScene(2);
    }

    public void OnCaveButtonPress()
    {
        Debug.Log("cave");
        SceneManager.LoadScene(3);
    }

    public void OnCancelButtonPress()
    {
        ToggleInteract();
    }

    public void ToggleInteract()
    {
        if (_canvas.interactable == true)
        {
            _canvas.interactable = false;
            _canvas.alpha = 0f;
        }
        else if (_canvas.interactable == false)
        {
            _canvas.interactable = true;
            _canvas.alpha = 1f;
        }
    }
}
