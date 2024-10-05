using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform target;
    protected Rigidbody2D rb;
    protected Animator animator;
    [SerializeField] protected float damage;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attackIntervalTime;
    protected float attackIntervalTimerCounter;
    protected bool isAttack { get; private set; }
    [SerializeField] protected float guardDistance;
    [SerializeField] public float knockDistance;
    [SerializeField] public float knockTime;
    [SerializeField] public float experience;
    protected Vector3 knockDir;
    protected bool isKnocked;
    protected float knockTimeCounter;
    public int facingDir { get; private set; }
    public bool isFacingRight { get; private set; } = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        attackIntervalTimerCounter -= Time.deltaTime;
        if (attackIntervalTimerCounter < 0)
            isAttack = false;
        if (knockTimeCounter > 0 && isKnocked)
        {
            knockTimeCounter -= Time.deltaTime;
            KnockedMove();
        }
        else
        {
            isKnocked = false;
        }
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    protected virtual void MoveToTarget()
    {
        if (target)
            SetVelocity((target.position - transform.position).normalized.x, (target.position - transform.position).normalized.y, moveSpeed, moveSpeed);
    }
    protected virtual void Attack(GameObject _target)
    {
        if (_target.CompareTag("Player") && attackIntervalTimerCounter < 0)
        {
            attackIntervalTimerCounter = attackIntervalTime;
            isAttack = true;
            AttackEffet();
        }
    }
    protected virtual void AttackEffet()
    {

    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
    }
    public void SetVelocity(float _xVelocity, float _yVelocity, float _xMoveSpeed = 0, float _yMoveSpeed = 0)
    {
        Vector2 velocity = new Vector2(_xVelocity, _yVelocity);
        velocity.Normalize();
        velocity.x *= _xMoveSpeed;
        velocity.y *= _yMoveSpeed;
        rb.velocity = velocity;
        FlipControl(_xVelocity);
    }
    private void Flip()
    {
        facingDir *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipControl(float _x)
    {
        if (_x > 0 && !isFacingRight && !isKnocked)
            Flip();
        else if (_x < 0 && isFacingRight && !isKnocked)
            Flip();
    }
    public virtual void KnockBackControl(Vector3 _knockDir)
    {
        if (knockDistance == 0)
            return;
        isKnocked = true;
        knockDir = _knockDir.normalized;
        knockTimeCounter = knockTime;
    }
    protected void KnockedMove()
    {
        float knockSpeed = knockDistance / knockTime;
        SetVelocity(knockDir.x, knockDir.y, knockSpeed, knockSpeed);
    }
}
