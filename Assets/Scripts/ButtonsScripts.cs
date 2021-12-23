using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScripts : MonoBehaviour
{
    // reset game method
    public void ResetGame()
    {
        // scene maganer load scene LoadScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }

    // next scene method
    public void StartGame()
    {
        // next scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
    }
}
