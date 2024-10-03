using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    [SerializeField] private float gameOverTime;
    private float gameTimer;
    public GameObject player { get; private set; }
    public PlayerHealthControl playerHealthControl { get; private set; }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealthControl = player.GetComponent<PlayerHealthControl>();
    }
    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        int minutes = (int)gameTimer / 60;
        float seconds = gameTimer % 60;
        //Debug.Log (minutes + "£º" + string.Format("{0:00}", seconds));
        if (playerHealthControl.currentHealth <= 0)
            GameOver();
        if (minutes > gameOverTime) 
            GameWin();
    }
    public void GameWin()
    { 

    }
    public void GameOver() 
    {

    }
    public void Initiate()
    {
        
    }
}
