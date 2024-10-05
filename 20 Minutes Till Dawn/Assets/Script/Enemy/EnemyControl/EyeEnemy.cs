using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemy : Enemy
{
    public GameObject bulletPrefab;
    public float destroyDistance;
    public float shootingSpeed;
    public float bulletDamage;
    protected override void Update()
    {
        base.Update();
        if (target)
        {
            if (Vector2.Distance(transform.position, target.position) < guardDistance)
                Attack(target.gameObject);
            if (!isKnocked && !isAttack)
                MoveToTarget();
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
        SetVelocity(0, 0, 0, 0);
        FlipControl((target.position - transform.position).x);
        base.AttackEffet();
        Bullet bullet =  Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
        bullet.BulletInitiate(target.position - transform.position, shootingSpeed, destroyDistance, bulletDamage);
    }

    protected override void MoveToTarget()
    {
        base.MoveToTarget();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
