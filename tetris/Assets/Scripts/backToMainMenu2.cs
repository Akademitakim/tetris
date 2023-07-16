using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class backToMainMenu2 : MonoBehaviour
{

    public string targetSceneName = "MainMenu";

    private void OnMouseDown()
    {
        LoadTargetScene();
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

}
