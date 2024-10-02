using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
        Debug.Log("Œ“À¿¿≤");
    }
}
