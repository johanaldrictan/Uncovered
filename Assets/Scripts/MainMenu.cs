using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickPlay() {
        Debug.Log("aAAAAAAAAA");
        SceneManager.LoadScene(1);
    }

    public void ClickQuit() {
        Debug.Log("aAAAAAAAAA");
        Application.Quit();
    }

    public void ClickCredits() {

    }
}
