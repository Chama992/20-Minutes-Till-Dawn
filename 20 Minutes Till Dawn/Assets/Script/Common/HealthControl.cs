using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] public float maxHealthValue;
    public float currentHealth { get; private set; }
    private void Start()
    {
        currentHealth = maxHealthValue;
    }
    private void Update()
    {
    }
    public void GetHurt(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
            DeadCheck();
    }
    public virtual void DeadCheck()
    {
    }
    
}
