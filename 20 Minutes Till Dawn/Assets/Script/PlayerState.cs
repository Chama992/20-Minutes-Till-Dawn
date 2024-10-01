using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBoolName;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D rb;
    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        rb = player.Rb;
    }
    public virtual void Enter()
    {
        player.Anim.SetBool(animBoolName, true);

    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
    }
}
