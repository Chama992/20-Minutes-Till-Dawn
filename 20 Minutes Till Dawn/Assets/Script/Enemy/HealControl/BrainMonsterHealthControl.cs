using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMonsterHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
        Destroy(gameObject);
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
    }
}
