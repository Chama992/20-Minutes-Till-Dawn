using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainMonsterEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();
        if (!isKnocked && target)
            MoveToTarget();
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player") && attackIntervalTimerCounter < 0)
        {
            attackIntervalTimerCounter = attackIntervalTime;
            collision.gameObject.GetComponent<PlayerHealthControl>().GetHurt(1);
            KnockBackControl(transform.position - collision.transform.position);
        }
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
