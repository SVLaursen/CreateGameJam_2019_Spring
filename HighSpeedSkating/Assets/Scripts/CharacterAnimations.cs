using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class CharacterAnimations : MonoBehaviour
{
    public UnityArmatureComponent animationController;

    private void Update()
    {
        Debug.Log(animationController.animation.lastAnimationName);
    }

    public void Standing()
    {
        if (animationController.animation.lastAnimationName == "idle_anim") return;
        animationController.animation.FadeIn("idle_anim", -1, 0);
    }

    public void Kneeling()
    {
        if (animationController.animation.lastAnimationName == "kneel_down") return;
        animationController.animation.FadeIn("kneel_down", -1, 0);
    }

    public void LeanFwd()
    {
        animationController.animation.Stop();
        //if (animationController.animation.lastAnimationName == "forward") return;
        animationController.animation.FadeIn("forward", -1, 0);
    }

    public void LeanBwd()
    {
        if (animationController.animation.lastAnimationName == "backward") return;
        animationController.animation.FadeIn("backward", -1, 0);
    }

    public void Fall()
    {
        if (animationController.animation.lastAnimationName == "fall_anim") return;
        animationController.animation.FadeIn("fall_anim", -1, 1);
    }
}
