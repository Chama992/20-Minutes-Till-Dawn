using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyDistance;
    public Transform Owner { get; private set; }
    public Vector3 generatePosition { get; private set; }
    public  Rigidbody2D Rigidbody { get; private set; }
    public Vector3 shootingDir { get; private set; }
    public float shootingSpeed { get; private set; }
    public float bulletDamage { get; private set; }
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
        if (Vector3.Distance(generatePosition, transform.position) >= destroyDistance)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            EffectOfBullet(collision.transform);
    }
    protected virtual void EffectOfBullet(Transform _target)
    { 
    }

    protected virtual void BulletMove()
    { 
    }
    public void BulletInitiate(Vector3 _shootingDir,float _speed, float _shootingScale, float _bulletDamage)
    {
        shootingDir = _shootingDir;
        shootingSpeed = _speed;
        bulletDamage = _bulletDamage;
        destroyDistance = _shootingScale;
        float angle = Mathf.Atan2(_shootingDir.y, _shootingDir.x) * Mathf.Rad2Deg;
        Quaternion weaponQuaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 weaponRotation = weaponQuaternion.eulerAngles;
        transform.rotation = Quaternion.Euler(weaponRotation);
    }
}
