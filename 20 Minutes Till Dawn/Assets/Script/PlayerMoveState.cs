using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (xInput == 0 && yInput == 0)
            stateMachine.ChangeState(player.IdleState);
        else
            player.SetVelocity(xInput, yInput, player.moveSpeed, player.moveSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
