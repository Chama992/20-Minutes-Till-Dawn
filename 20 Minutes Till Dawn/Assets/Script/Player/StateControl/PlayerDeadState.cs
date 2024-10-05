using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public float DeadTimer = 1;
    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0,0,0,0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        DeadTimer -= Time.deltaTime;
        if (DeadTimer < 0)
        {
            player.Weapon.SetActive(false);
            player.gameObject.SetActive(false);
        }

        base.Update();
    }
}
