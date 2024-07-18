using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private string SceneName = "MainScene";

    public void begin()
    {

        SceneManager.LoadScene(SceneName);
        
    }
}
