using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoomerHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
        ExperienceControll.instance.GenerateJewel(transform.position, gameObject.GetComponent<Enemy>().experience);
        gameObject.GetComponent<BigBoomerEnemy>().ExplodeBegin();
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
    }
}
