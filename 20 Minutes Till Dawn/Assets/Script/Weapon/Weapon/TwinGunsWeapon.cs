using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoGunWeapon : Weapon
{
    public override void ShootBullets(Vector3 _shootingDir)
    {
        base.ShootBullets(_shootingDir);
        Vector3 shootingPoint = ShootingPoint.position;
        float deviation = 0.05f;
        float angle = Vector3.Angle(Vector3.right, _shootingDir);
        Vector3 generatePosition1 = new Vector3(shootingPoint.x - deviation * Mathf.Sin(angle * Mathf.Deg2Rad), shootingPoint.y + deviation * Mathf.Cos(angle * Mathf.Deg2Rad), shootingPoint.z);
        Vector3 generatePosition2 = new Vector3(shootingPoint.x + deviation * Mathf.Sin(angle * Mathf.Deg2Rad), shootingPoint.y - deviation * Mathf.Cos(angle * Mathf.Deg2Rad), shootingPoint.z);
        Bullet bulletController1 = Instantiate(bullet, generatePosition1, Quaternion.Euler(_shootingDir)).GetComponent<Bullet>();
        Bullet bulletController2 = Instantiate(bullet, generatePosition2, Quaternion.Euler(_shootingDir)).GetComponent<Bullet>();
        bulletController1.BulletInitiate(_shootingDir, bulletSpeed, ShootingScale, damage);
        bulletController2.BulletInitiate(_shootingDir, bulletSpeed, ShootingScale, damage);
    }
}
