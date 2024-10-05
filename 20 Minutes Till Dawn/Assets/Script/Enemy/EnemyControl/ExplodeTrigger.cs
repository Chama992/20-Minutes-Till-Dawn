using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeTrigger : MonoBehaviour 
{
    public BigBoomerEnemy enemy => GetComponentInParent<BigBoomerEnemy>();
    public void Explode()
    {
        enemy.Explode();
    }
}
