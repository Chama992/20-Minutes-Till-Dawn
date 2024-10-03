using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    [SerializeField] private float damage; 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackIntervalTime;
    private float attackIntervalTimerCounter;
    [SerializeField] private float guardDistance;
    
    public int facingDir { get; private set; }
    public bool isFacingRight { get; private set; } = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackIntervalTimerCounter -= Time.deltaTime;
        Move();
        if (Vector2.Distance(transform.position, target.position) < guardDistance)
            Attack();
        
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    protected virtual void Move()
    {
        SetVelocity((target.position - transform.position).normalized.x, (target.position - transform.position).normalized.y, moveSpeed, moveSpeed);
    }
    protected virtual void Attack()
    { 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && attackIntervalTimerCounter < 0)
        {
            attackIntervalTimerCounter = attackIntervalTime;
            collision.gameObject.GetComponent<PlayerHealthControl>().GetHurt(damage);
        }
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
    private void FlipControl(float _x)
    {
        if (_x > 0 && !isFacingRight)
            Flip();
        else if (_x < 0 && isFacingRight)
            Flip();
    }

}
