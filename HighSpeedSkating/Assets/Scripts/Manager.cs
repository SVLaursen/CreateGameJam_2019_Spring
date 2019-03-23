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
    private bool showGameOver;

    public Canvas pauseScreen;
    public Canvas gameOverScreen;
    public Canvas uiCanvas;

    [Header("UI Text")]
    public Text speedText;
    public Text lenghtText;

    [Header("Other UI")]
    public Slider balanceSlider;
    public Slider strainSlider;

    [Header("Game Over UI")]
    public Text gameOverSpeed;
    public Text gameOverLength;

    [Header("Game Over + Pausing Stuff")]
    public bool gameOver;
    public bool paused;

    [Header("BackgroundManager")]
    public float scrollSpeed = -4f;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        startPosition = player.transform.position;

        balanceSlider.maxValue = player.maxBalance;
        balanceSlider.minValue = -player.maxBalance;

        strainSlider.maxValue = player.maxStrain;
        strainSlider.minValue = 0;

        if (pauseScreen != null)
            pauseScreen.enabled = false;
        if (gameOverScreen != null)
            gameOverScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
            paused = true;
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
            paused = false; 

        pauseScreen.enabled = paused;

        balanceSlider.maxValue = player.maxBalance;
        balanceSlider.minValue = -player.maxBalance;

        strainSlider.maxValue = player.maxStrain;

        balanceSlider.value = player.balance;
        strainSlider.value = player.strain;

        if (paused)
            player.transform.position = player.transform.position;

        if (!gameOver)
        {
            currentPosition = player.transform.position;
            lenghtTravelled = Mathf.Round(currentPosition.x - startPosition.x);
            speedText.text = player.speed.ToString("0.00") + "km/h";
            lenghtText.text = lenghtTravelled / 10 + "M";
        }
        else
        {
            StartCoroutine(Wait(2));
            if (!showGameOver) return;
            gameOverScreen.enabled = true;
            gameOverSpeed.text = player.speed.ToString("0.00") + "km/h";
            gameOverLength.text = lenghtText.text = lenghtTravelled / 10 + "M";
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

    private IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        showGameOver = true;
    }
}
