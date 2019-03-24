using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DragonBones;

public class CutsceneController : MonoBehaviour
{
    public UnityArmatureComponent copController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndLoad());
        copController.animation.Play("running_anim", -1);
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(2);
    }
}
