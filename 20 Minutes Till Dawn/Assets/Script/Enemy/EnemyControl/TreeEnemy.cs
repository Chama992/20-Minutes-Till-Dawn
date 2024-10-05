using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : Enemy
{
    private float checkTime = 0.2f;
    private float checkTimeCounter;
    public float checkRange;
    public bool isOpen = false;
    public LayerMask playerLayer;
    protected override void Start()
    {
        base.Start();
        rb.isKinematic = false;
    }
    protected override void Update()
    {
        base.Update();
        checkTimeCounter -= Time.deltaTime;
        if (checkTimeCounter <= 0)
        {
            checkTimeCounter = checkTime;
            Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, checkRange, playerLayer);
            if (playerCollider && !isOpen)
            {
                animator.SetBool("OpenEye", true);
                isOpen = true;
            }
            else if (!playerCollider)
            {
                animator.SetBool("OpenEye", false);
                isOpen = false;
            }

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
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthControl>().GetHurt(1);
        }
    }
}
