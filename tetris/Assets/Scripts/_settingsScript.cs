using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class _settingsScript : MonoBehaviour
{

    public string targetSceneName = "Settings";

    private void OnMouseDown()
    {
        LoadTargetScene();
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

}

