using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadUI : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void InGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
