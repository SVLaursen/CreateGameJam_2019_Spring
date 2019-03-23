﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public PlayerInfo playerInfo;

    public float balance;
    public float strain;

    public float maxBalance;
    public float maxStrain; 

    private Rigidbody2D _rb;
    private Manager gameManager;

    private bool failShake;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<Manager>().GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.gameOver) {
            Debug.Log("YOU LOSE");
            if (!failShake)
            {
                FindObjectOfType<CameraController>().StandardCameraShake();
                failShake = true;
            }
            return; 
         }

        //Falling off? Recode later (this is just a test)
        if (balance >= maxBalance || balance <= -maxBalance)
            gameManager.gameOver = true;

        if(strain >= maxStrain)
            gameManager.gameOver = true;

        //Left Input
        playerInfo.leaningBwd |= Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S);

        //Right Input
        playerInfo.leaningFwd |= Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S);

        //Down Input
        playerInfo.knealing |= Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);

        if (playerInfo.leaningFwd)
            LeanFwd();
        if (playerInfo.leaningBwd)
            LeanBwd();
        if (playerInfo.knealing)
            Kneal();
        else
            Stand();

        Vector2 boardSpeed = new Vector2(speed, 0);
        _rb.AddForce(boardSpeed);
        //Debug.Log(_rb.velocity);

        if (!Input.anyKey)
            playerInfo.Reset();
    }

    private void LeanFwd()
    {
        Debug.Log("Leaning forward");
        speed = speed + Time.deltaTime + playerInfo.leanSpeed;
        strain += 0.01f; //Might want to put a variable on this
        balance -= 0.01f;
    }

    private void LeanBwd()
    {
        Debug.Log("Leaning backwards");
        speed = 0;
        strain += 0.01f;

        if(balance != 0)
        {
            if (balance < 0)
                balance += 0.1f;
            if (balance > 0)
                balance += 0.1f;
        }
    }

    private void Kneal()
    {
        Debug.Log("Knealing");
        speed = speed + Time.deltaTime + playerInfo.kneelSpeed;
        strain += .05f;
        balance += .05f;
    }

    private void Stand()
    {
        Debug.Log("Standing");
        speed = speed + Time.deltaTime;
        balance -= 0.01f;

        if (strain > 0)
            strain -= 0.01f;
    }

    [System.Serializable]
    public struct PlayerInfo
    {
        public bool leaningFwd, leaningBwd, knealing, standing;
        public float leanSpeed;
        public float kneelSpeed;

        public void Reset()
        {
            leaningBwd = false;
            leaningFwd = false;
            knealing = false;
            standing = true;
        }
    }
}
