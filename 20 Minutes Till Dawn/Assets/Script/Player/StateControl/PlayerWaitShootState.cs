using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitShootState : PlayerState
{
    public PlayerWaitShootState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKey(KeyCode.Mouse0) && !player.weapon.IsLoading)
            stateMachine.ChangeState(player.ShootState);
    }
}
