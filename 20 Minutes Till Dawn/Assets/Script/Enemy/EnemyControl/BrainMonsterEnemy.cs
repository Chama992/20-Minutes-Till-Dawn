using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMonsterEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();
        if (!isKnocked)
            MoveToTarget();
        //if (Vector2.Distance(transform.position, target.position) < guardDistance)
        //    Attack(target.gameObject);
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void Attack(GameObject _target)
    {
        base.Attack(_target);
    }

    protected override void AttackEffet()
    {
        base.AttackEffet();
    }
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    public override void KnockBackControl(Vector3 _knockDir)
    {
        base.KnockBackControl(_knockDir);
    }
}
