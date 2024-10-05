using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadChoose : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Again()
    {
        SceneManager.LoadScene("InGame");
    }
}
