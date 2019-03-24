using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Lose : MonoBehaviour
{
    private Manager manager;
    private UnityArmatureComponent controller;

    public GameObject cop;

    // Start is called before the first frame update
    void Start()
    {
        cop.SetActive(false);
        manager = FindObjectOfType<Manager>().GetComponent<Manager>();
    }

    private void Awake()
    {
        controller.animation.Play("idle_anim", -1);
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.gameOver)
        {
            cop.SetActive(true);
        }

    }
}
