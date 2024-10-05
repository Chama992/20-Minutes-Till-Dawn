using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
        ExperienceControll.instance.GenerateJewel(transform.position, gameObject.GetComponent<Enemy>().experience);
        Destroy(gameObject);
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
    }
}
