using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Setup")]
    public GameObject mainScreen;
    public GameObject howToScreen;

    [Header("Audio FX")]
    public AudioSource[] sfx;

    private void Start()
    {
        Back();
    }

    public void StartGame()
    {
        var clip = RandomSound();
        clip.Play();

        StartCoroutine(WaitFor((int)clip.time));
      
    }

    public void HowTo()
    {
        RandomSound().Play();
        mainScreen.SetActive(false);
        howToScreen.SetActive(true);
    }

    public void Back()
    {
        RandomSound().Play();

        mainScreen.SetActive(true);
        howToScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private AudioSource RandomSound()
    {
        return sfx[Random.Range(0, sfx.Length)];
    }

    private IEnumerator WaitFor(int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }
}
