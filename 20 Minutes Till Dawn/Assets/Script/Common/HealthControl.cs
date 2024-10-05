using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField] public float maxHealthValue;
    [SerializeField] public float currentHealth;
    protected virtual void Start()
    {
        currentHealth = maxHealthValue;
    }
    private void Update()
    {
    }
    public virtual void GetHurt(float _damage)
    {
        currentHealth -= _damage;
        if (currentHealth <= 0)
            DeadCheck();
    }
    public virtual void DeadCheck()
    {
    }
    
}
