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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackIntervalTimerCounter -= Time.deltaTime;
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    protected virtual void Move()
    {
        //rb.velocity = (target.position - transform.position).normalized * moveSpeed;
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
}
