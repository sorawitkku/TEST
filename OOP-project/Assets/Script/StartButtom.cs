using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour
{
    public string[] sceneNames;
    public void OnClickToStart()
    {
        string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickToQuit()
    {
        Application.Quit();
    }
}
