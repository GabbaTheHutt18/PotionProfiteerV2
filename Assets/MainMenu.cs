using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //when play button pressed loads the game scene
    public void PlayButton()
    {
        // This would be where the next scene is loaded, simple enough to add, just need to be sure what scene it is going into
        Debug.Log("You have would have started the game");
        SceneManager.LoadScene(1);
    }

    //when quit button pressed quits the game
    public void QuitButton()
    {
        Debug.Log("you have quit the game");
        Application.Quit();
    }

}
