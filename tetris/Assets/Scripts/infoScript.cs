using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class infoScript : MonoBehaviour
{

    public string targetSceneName = "infoScene";

    private void OnMouseDown()
    {
        LoadTargetScene();
    }

    private void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

}
