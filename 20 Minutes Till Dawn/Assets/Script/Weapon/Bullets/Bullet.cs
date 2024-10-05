using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float DestroyDistance { get; private set; }
    public float ShootingSpeed { get; private set; }
    public float BulletDamage { get; private set; }
    public Vector3 ShootingDir { get; private set; }
    public Transform Owner { get; private set; }
    public Vector3 generatePosition { get; private set; }
    public  Rigidbody2D Rigidbody { get; private set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Owner = GameObject.FindWithTag("Player").transform;
        Rigidbody = GetComponent<Rigidbody2D>();
        generatePosition = Owner.transform.position;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        if (Vector3.Distance(generatePosition, transform.position) >= DestroyDistance)
            Destroy(gameObject);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
    }
    protected virtual void EffectOfBullet(Transform _target)
    { 
    }

    protected virtual void BulletMove()
    { 
    }
    public void BulletInitiate(Vector3 _shootingDir,float _speed, float _shootingScale, float _bulletDamage)
    {
        ShootingDir = _shootingDir;
        ShootingSpeed = _speed;
        BulletDamage = _bulletDamage;
        DestroyDistance = _shootingScale;
        float angle = Mathf.Atan2(_shootingDir.y, _shootingDir.x) * Mathf.Rad2Deg;
        Quaternion weaponQuaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 weaponRotation = weaponQuaternion.eulerAngles;
        transform.rotation = Quaternion.Euler(weaponRotation);
    }
}
