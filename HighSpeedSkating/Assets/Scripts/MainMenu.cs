using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject howToScreen;

    private void Start()
    {
        Back();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowTo()
    {
        mainScreen.SetActive(false);
        howToScreen.SetActive(true);
    }

    public void Back()
    {
        mainScreen.SetActive(true);
        howToScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
