using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillState : PlayerState
{
    private float shootTimer;
    public PlayerSkillState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        shootTimer = player.shootingSkillIntervalTime;
        player.SetVelocity(0, 0, 0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        player.Weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
    }

    public override void Update()
    {
        base.Update();
        if (player.WeaponControl.BulletCurrentCount < player.WeaponControl.bulletCountPerShoot)
        {
            player.WeaponControl.Load();
            stateMachine.ChangeState(player.IdleState);
        }
        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;
        else if (shootTimer < 0 /*&& player.WeaponControl.BulletCurrentCount >= player.WeaponControl.bulletCountPerShoot*/)
        {
            RandomShoot(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
            shootTimer = player.shootingSkillIntervalTime;
        }
        if (xInput != 0 || yInput != 0)
            player.SetVelocity(xInput, yInput, player.skillMoveSpeed, player.skillMoveSpeed);
    }
    private void RandomShoot(Vector3 _shootingDir )
    {
        player.WeaponControl.ShootBullets(_shootingDir);
    }
}
