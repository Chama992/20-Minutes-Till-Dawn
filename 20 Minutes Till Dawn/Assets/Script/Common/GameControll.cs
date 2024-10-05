using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControll : MonoBehaviour
{
    public static GameControll instance;
    [SerializeField] private float gameOverTime;
    private float GameTime;
    private float gameTimer;
    public GameObject player { get; private set; }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GameTime = gameOverTime * 60;
    }
    // Update is called once per frame
    void Update()
    {
        int minutes = (int)GameTime / 60;
        float seconds = GameTime % 60;
        gameTimer += Time.deltaTime;
        if (gameTimer >= 1f)
        {
            gameTimer = 0;
            GameTime--;
            UIControl.instance.UpdateGameTime(minutes + ":" + string.Format("{0:00}", seconds));
        }
        if (GameTime <= 0) 
            GameWin();
    }
    public void GameWin()
    {
    }
    public void GameOver() 
    {
        UIControl.instance.OpenDeadCanvas();
    }
}
