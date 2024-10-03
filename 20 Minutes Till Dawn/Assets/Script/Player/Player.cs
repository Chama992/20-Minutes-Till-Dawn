using System.Collections;
using System.Collections.Generic;
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
    public Weapon weapon { get; private set; }
    #endregion
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        ShootState = new PlayerShootState(this, StateMachine, "Shoot");
        weapon = GameObject.FindWithTag("PlayerWeapon").GetComponent<Weapon>();
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
}
