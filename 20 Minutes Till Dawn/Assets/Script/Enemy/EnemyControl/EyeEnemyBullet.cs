using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeEnemyBullet : Bullet
{
    protected override void BulletMove()
    {
        base.BulletMove();
        Rigidbody.velocity = Vector3.Normalize(ShootingDir) * ShootingSpeed;
    }

    protected override void EffectOfBullet(Transform _target)
    {
        base.EffectOfBullet(_target);
        Destroy(gameObject);
        _target.gameObject.GetComponent<HealthControl>().GetHurt(BulletDamage);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
            EffectOfBullet(collision.transform);
    }

    protected override void Start()
    {
        base.Start();
        BulletMove();
    }

    protected override void Update()
    {
        base.Update();
    }
}
