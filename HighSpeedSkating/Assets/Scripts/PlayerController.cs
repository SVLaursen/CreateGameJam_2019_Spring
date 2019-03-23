using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public PlayerInfo playerInfo;

    public float balance;
    public float strain;

    [HideInInspector] public float maxBalance;
    [HideInInspector] public float maxStrain;

    [Header("Balance Stuff")]
    public float startBalance;
    public float startStrain;
    public float diffBalance;
    public float diffStrain;
    public float hardBalance;
    public float hardStrain;
    public float deathBalance;
    public float deathStrain;

    public CameraShaker.Properties diffShake;
    public CameraShaker.Properties hardShake;
    public CameraShaker.Properties deathShake;

    private Rigidbody2D _rb;
    private Manager gameManager;
    private CameraController cameraController;

    private bool failShake;
    private bool difficultyIncreased;
    private Vector2 oldPosition;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<Manager>().GetComponent<Manager>();
        cameraController = FindObjectOfType<CameraController>().GetComponent<CameraController>();
        maxStrain = startStrain;
        maxBalance = startBalance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.paused)
        {
            transform.position = oldPosition;
            return;
        }

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
        playerInfo.kneeling |= Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D);

        if (Input.GetKeyDown(KeyCode.W))
        {
            //TODO: Taunt sounds and graphics shows up
        }

        if (playerInfo.leaningFwd)
            LeanFwd();
        if (playerInfo.leaningBwd)
            LeanBwd();
        if (playerInfo.kneeling)
            Kneal();
        else
            Stand();

        Vector2 boardSpeed = new Vector2(speed, 0);
        _rb.AddForce(boardSpeed);
        //Debug.Log(_rb.velocity);

        if (strain < 0)
            strain = 0;

        if (!Input.anyKey)
            playerInfo.Reset();

        oldPosition = transform.position;

        if (gameManager.gameOver) return;
        CalculateDifficulty();
    }

    private void LeanFwd()
    {
        Debug.Log("Leaning forward");
        speed = speed + Time.deltaTime + playerInfo.leanSpeed;
        strain -= 0.02f; //Might want to put a variable on this
        balance -= 0.01f;
    }

    private void LeanBwd()
    {
        Debug.Log("Leaning backwards");
        speed -= 0.03f;
        strain += 0.01f;

        if(balance != 0)
        {
            if (balance < 0)
                balance += 0.1f;
            if (balance > 0)
                balance -= 0.1f;
        }
    }

    private void Kneal()
    {
        Debug.Log("Knealing");
        speed = speed + Time.deltaTime + playerInfo.kneelSpeed * 2;
        strain += .05f;
        balance += .05f;
    }

    private void Stand()
    {
        // Debug.Log("Standing");
        speed = speed + Time.deltaTime;
        balance -= 0.01f;

        if (strain > 0)
            strain -= 0.02f;
    }

    private void CalculateDifficulty()
    {
        if(speed > 100 )
        {
            maxBalance = diffBalance;
            maxStrain = diffStrain;
            cameraController.ShakeCamera(diffShake);
        }
        if(speed > 200)
        {
            maxBalance = hardBalance;
            maxStrain = hardStrain;
            cameraController.ShakeCamera(hardShake);
        }
        if(speed > 300)
        {
            maxStrain = deathStrain;
            maxBalance = deathBalance;
            cameraController.ShakeCamera(deathShake);
        }
    }

    [System.Serializable]
    public struct PlayerInfo
    {
        public bool leaningFwd, leaningBwd, kneeling, standing;
        public float leanSpeed;
        public float kneelSpeed;

        public void Reset()
        {
            leaningBwd = false;
            leaningFwd = false;
            kneeling = false;
            standing = true;
        }
    }
}
