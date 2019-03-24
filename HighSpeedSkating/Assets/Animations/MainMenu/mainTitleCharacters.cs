using UnityEngine;
using DragonBones;

public class mainTitleCharacters : MonoBehaviour
{
    private UnityArmatureComponent controller;
    public string animationName;

    private void Start()
    {
        controller = GetComponent<UnityArmatureComponent>();
    }

    private void Awake()
    {
        controller.animation.Play(animationName, -1);
    }
}
