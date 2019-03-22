using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private PlayerController player;

    public Canvas pauseScreen;
    public Canvas gameOverScreen;
    public Canvas uiCanvas;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
