using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Bullet Info")]
    [SerializeField] public float damage;
    [SerializeField] public float shootingSpeed;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public int bulletTotalCount;
    [SerializeField] public int bulletCountPerShoot;
    [SerializeField] public float loadingTime;
    [SerializeField] public int BulletCurrentCount;
    [SerializeField] public float ShootingScale;
    [SerializeField] public float LoadingTimer { get; private set; }
    [SerializeField] public GameObject bullet;
    public bool IsLoading { get; private set; } = false;
    public bool FacingRight { get; private set; } = true;
    [SerializeField] public float ShootIntervalTimer { get; private set; }
    #region Conponents
    public Transform Owner { get; private set; }
    public Transform WeaponChild { get; private set; }
    public Transform ShootingPoint { get; private set; }
    public Animator WeaponAnimator { get; private set; }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        BulletCurrentCount = bulletTotalCount;
        WeaponChild = transform.GetChild(0);
        Owner = GameObject.FindGameObjectWithTag("Player").transform;
        WeaponAnimator = WeaponChild.GetComponent<Animator>();
        ShootingPoint = WeaponChild.GetChild(0);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Owner.position;
        //get mouse position
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseWorldPosition.z = 0;
        //rotate
        RotateWeapon(mouseWorldPosition);
        //flip
        FlipControl(mouseWorldPosition);
        if (IsLoading)
        {
            LoadControl();
        }
        //use to shootspeed
        ShootIntervalTimer -= Time.deltaTime;
    }

    private void RotateWeapon(Vector3 mouseWorldPosition)
    {
        Vector2 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion weaponQuaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 weaponRotation = weaponQuaternion.eulerAngles;
        transform.rotation = Quaternion.Euler(weaponRotation);
    }
    private void FlipControl(Vector3 mouseWorldPosition)
    {
        if (mouseWorldPosition.x > transform.position.x && !FacingRight)
        {
            //transform.Rotate(180, 0, 0);
            WeaponChild.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            FacingRight = !FacingRight;
            //Debug.Log("flip");
        }
        else if (mouseWorldPosition.x < transform.position.x && FacingRight)
        {
            //transform.Rotate(180, 0, 0);
            WeaponChild.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
            FacingRight = !FacingRight;
            //Debug.Log("flip");
        }
    }
    public void Load()
    {
        WeaponAnimator.SetBool("Loaded", true);
        LoadingTimer = loadingTime;
        IsLoading = true;
    }
    private void LoadControl()
    {
        LoadingTimer -= Time.deltaTime;
        if (LoadingTimer <= 0)
        {
            IsLoading = false;
            BulletCurrentCount = bulletTotalCount;
            WeaponAnimator.SetBool("Loaded", false);
        }
    }
    public virtual void ShootBullets( Vector3 _shootingDir)
    {
        BulletCurrentCount -= bulletCountPerShoot;
        ShootIntervalTimer = 1 / shootingSpeed;
        //Debug.Log(BulletCurrentCount);
        if (BulletCurrentCount <= 0)
        {
            Load();
        }
    }
}
