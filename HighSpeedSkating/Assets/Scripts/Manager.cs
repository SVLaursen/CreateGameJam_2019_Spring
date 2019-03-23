using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private PlayerController player;

    private Vector2 startPosition;
    private Vector2 currentPosition;

    private float lenghtTravelled;

    public Canvas pauseScreen;
    public Canvas gameOverScreen;
    public Canvas uiCanvas;

    [Header("UI Text")]
    public Text speedText;
    public Text lenghtText;

    [Header("Game Over + Pausing Stuff")]
    public bool gameOver;
    public bool paused;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        startPosition = player.transform.position;

        if (pauseScreen != null)
            pauseScreen.enabled = false;
        if (gameOverScreen != null)
            pauseScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            paused = true;
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
            paused = false; 

        pauseScreen.enabled = paused;

        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        if (!gameOver)
        {
            currentPosition = player.transform.position;
            lenghtTravelled = Mathf.Round(currentPosition.x - startPosition.x);
            speedText.text = player.speed.ToString("0.00") + "km/h";
            lenghtText.text = lenghtTravelled + "M";
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
