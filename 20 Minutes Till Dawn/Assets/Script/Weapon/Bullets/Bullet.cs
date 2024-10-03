using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyDistance;
    private Transform owner;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        owner = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            EffectOfBullet(collision.transform);
    }
    protected virtual void EffectOfBullet(Transform _target)
    { 
    }

    protected virtual void InitiateMove()
    { 
    }
}
