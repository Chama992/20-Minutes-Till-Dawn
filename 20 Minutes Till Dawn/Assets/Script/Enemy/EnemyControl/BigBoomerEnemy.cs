using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BigBoomerEnemy : Enemy
{
    [SerializeField] public float explodeRad;
    [SerializeField] public LayerMask layerOfPlayer;
    public bool IsExloding { get; private set; }
    protected override void Update()
    {
        base.Update();
        if(target)
        {
            if (!isKnocked)
                MoveToTarget();
            if (Vector3.Distance(transform.position, target.position) < explodeRad)
                ExplodeBegin();
            if (IsExloding)
                SetVelocity(0, 0, 0, 0);
        }
    }
    public override void KnockBackControl(Vector3 _knockDir)
    {
        base.KnockBackControl(_knockDir);
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
        animator.SetBool("Move", true);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthControl>().GetHurt(1);
            ExplodeBegin();
        }
    }
    public void ExplodeBegin()
    {
        if (!gameObject.GetComponent<BigBoomerEnemy>().IsExloding)
        {
            isKnocked = false;
            IsExloding = true;
            animator.SetBool("Move", false);
            animator.SetBool("Explode", true);
        }
    }
    public void Explode()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, explodeRad, layerOfPlayer);
        if (collider != null)
        {
            if (collider.gameObject.GetComponent<HealthControl>())
                collider.gameObject.GetComponent<HealthControl>().GetHurt(1);
        }
        Destroy(gameObject);
    }
}
