using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemyHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
        currentHealth = maxHealthValue;
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
    }

    protected override void Start()
    {
        base.Start();
    }
}
