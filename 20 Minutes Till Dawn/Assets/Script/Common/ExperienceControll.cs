using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ExperienceControll:MonoBehaviour
{
    public static ExperienceControll instance;
    [SerializeField] public float experiencePickRange;
    [SerializeField] public LayerMask experienceLayerMask;
    [SerializeField] public GameObject experienceJewel;
        //private List<GameObject> jewels;
    public int Rank { get; private set; }
    public List<float> explevels;
    public int levelCount = 100;
    public float CurrentExperience { get; private set; }
    private void Awake()
    {
        instance = this;
        while (explevels.Count < levelCount)
        {
            explevels.Add(5 * explevels.Count);
        }
        //jewels = new List<GameObject>();
    }
    public void AddExperience(float _experience)
    {
        CurrentExperience += _experience;
        if (CurrentExperience >= explevels[Rank] && Rank < levelCount)
        {
            CurrentExperience = 0;
            Rank += 1;
            gameObject.GetComponent<PlayerHealthControl>().AddHealth(1);
        }
    }
    public void GenerateJewel(Vector3 _position, float _experience)
    {
        GameObject jewel = Instantiate(experienceJewel, _position , Quaternion.identity);
        jewel.transform.position = _position;
        jewel.GetComponent<ExperienceJewel>().SetExperience(_experience);
        jewel.SetActive(true);
    }
    // has bugs 
    //private GameObject GetJewelFromPool()
    //{
    //    GameObject jewel = null;
    //    if (jewels.Count == 0)
    //    {
    //        jewel = Instantiate(experienceJewel);
    //    }
    //    else
    //    {
    //        jewel = jewels[0];
    //        jewels.RemoveAt(0);
    //    }
    //    return jewel;
    //}
    //public void GetInPool(GameObject _jewel)
    //{
    //    if (_jewel.GetComponent<ExperienceJewel>())
    //    {
    //        jewels.Add(_jewel);
    //        _jewel.SetActive(false);
    //    }     
    //}
}
