using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
    }
}
