using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    private string menu = "Menu";

    public void returnToMenu()
    {
        SceneManager.LoadScene(menu);
    }
}
