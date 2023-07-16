using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class _play : MonoBehaviour
{

    public string targetSceneName = "GameScene";

    private void OnMouseDown()
    {
        LoadTargetScene();
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

}
