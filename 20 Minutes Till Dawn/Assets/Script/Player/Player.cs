using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    #endregion
    #region PlayerStates
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerShootState ShootState { get; private set; }
    public PlayerSkillState SkillState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion
    #region MoveInfo
    [Header("MoveInfo")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float shootMoveSpeed;
    #endregion
    #region Flip
    public int facingDir { get; private set; }
    public bool isFacingRight { get; private set; } = true;
    #endregion
    #region Weapon
    public GameObject Weapon { get; private set; }
    public Weapon WeaponControl { get; private set; }
    #endregion
    #region SkillInfo
    [SerializeField] public float shootingSkillIntervalTime;
    [SerializeField] public float skillMoveSpeed;
    #endregion
    #region ExperiencePoint
    public ExperienceControll ExperienceControll { get; private set; }
    private float checkTime = 0.2f;
    private float checkTimeCounter;
    #endregion
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        ShootState = new PlayerShootState(this, StateMachine, "Shoot");
        SkillState = new PlayerSkillState(this, StateMachine, "Skill");
        DeadState = new PlayerDeadState(this, StateMachine, "Dead");
        ExperienceControll = GetComponent<ExperienceControll>();
        Weapon = GameObject.FindWithTag("PlayerWeapon");
        WeaponControl = Weapon.GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.currentState.Update();
        CheckExperience();
    }
    public void SetVelocity(float _xVelocity, float _yVelocity, float _xMoveSpeed = 0, float _yMoveSpeed = 0, float facingDir = 0)
    {
        Vector2 velocity = new Vector2(_xVelocity, _yVelocity);
        velocity.Normalize();
        velocity.x *= _xMoveSpeed;
        velocity.y *= _yMoveSpeed;
        Rb.velocity = velocity;
        facingDir = facingDir == 0 ? _xVelocity:facingDir;
        FlipControl(facingDir);
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
    private void CheckExperience()
    {
        checkTimeCounter -= Time.deltaTime;
        if (checkTimeCounter <= 0)
        {
            checkTimeCounter = checkTime;
            Collider2D[] jewels = Physics2D.OverlapCircleAll(transform.position, ExperienceControll.experiencePickRange, ExperienceControll.experienceLayerMask.value);
            foreach (var jewel in jewels)
            {
                ExperienceJewel jewelControl = jewel.gameObject.GetComponent<ExperienceJewel>();
                if (jewelControl && !jewelControl.MovingToPlayer)
                {
                    jewelControl.MoveCheck(transform);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
