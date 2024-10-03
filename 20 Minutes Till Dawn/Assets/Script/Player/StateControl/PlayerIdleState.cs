using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerWaitShootState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0);
    }
    public override void Update()
    {
        base.Update();
        if (xInput !=0 || yInput != 0)
            stateMachine.ChangeState(player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }


}
