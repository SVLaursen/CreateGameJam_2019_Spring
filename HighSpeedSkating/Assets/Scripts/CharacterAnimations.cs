using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class CharacterAnimations : MonoBehaviour
{
    public UnityArmatureComponent controller;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            LeanBwd();
        if (Input.GetKey(KeyCode.S))
            Kneeling();
        if (Input.GetKey(KeyCode.D))
            LeanFwd();
        else if(!Input.anyKey && !FindObjectOfType<Manager>().GetComponent<Manager>().gameOver)
            Standing();
    }

    public void Standing()
    {
        if (controller.animation.lastAnimationName == "idle_anim") return;
        controller.animation.FadeIn("idle_anim", -1, 0);
    }

    public void Kneeling()
    {
        if (controller.animation.lastAnimationName == "kneel_down") return;
        controller.animation.FadeIn("kneel_down", -1, 0);
    }

    public void LeanFwd()
    {
        if (controller.animation.lastAnimationName == "forward") return;
        controller.animation.FadeIn("forward", -1, 0);
    }

    public void LeanBwd()
    {
        Debug.Log("Trying to lean backwards");

        if (controller.animation.lastAnimationName == "backward") return;
        controller.animation.Reset();
        controller.animation.FadeIn("backward", -1, 0);
        Debug.Log(controller.animation.lastAnimationName);
    }

    public void Fall()
    {
        if (controller.animation.lastAnimationName == "fall_anim") return;
        controller.animation.FadeIn("fall_anim", -1, 1);
    }
}
