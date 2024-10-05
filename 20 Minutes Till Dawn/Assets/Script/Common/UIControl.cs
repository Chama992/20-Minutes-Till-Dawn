using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;


public class UIControl : MonoBehaviour
{
    public static UIControl instance;
    public UnityEngine.UI.Slider ExperienceBar;
    public TMP_Text Level;
    public TMP_Text GameTime;
    public TMP_Text BulletCount;
    public Transform ScrollViewContent;
    public UnityEngine.UI.Image Heart;
    public Canvas DeadCanvas;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUILevel(float currentExp, float maxEXP, int level)
    {
        ExperienceBar.value = currentExp;
        ExperienceBar.maxValue = maxEXP;
        Level.text = $"Level:{level}";
    }
    public void UpdateGameTime(string gameTime)
    {
        GameTime.text = gameTime;
    }
    public void UpdateBullet(int cur, int max)
    {
        BulletCount.text = (cur + "/" + max).ToString();
    }
    public void SetHealth(int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            Instantiate(Heart, ScrollViewContent);
        }
    }
    public void UpdateHealth(int damage = 0, int add = 0)
    {   
        for (int i = 0; i< damage; i++)
            Destroy(ScrollViewContent.GetChild(ScrollViewContent.childCount - 1).gameObject);
        for (int i = 0; i < add; i++)
            Instantiate(Heart, ScrollViewContent); 
    }
    public void OpenDeadCanvas()
    {
        DeadCanvas.gameObject.SetActive(true);
    }
}
