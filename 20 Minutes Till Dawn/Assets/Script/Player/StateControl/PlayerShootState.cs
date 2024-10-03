using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootState : PlayerState
{
    public PlayerShootState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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
        float facingDir = player.facingDir;
        if (!Input.GetKey(KeyCode.Mouse0) || player.weapon.IsLoading)
            stateMachine.ChangeState(player.IdleState);
        else
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.z));
            if (mouseWorldPos.x > player.transform.position.x)
                facingDir = 1;
            else
                facingDir = -1;
            // check if you can shoot
            if (!player.weapon.IsLoading && player.weapon.ShootIntervalTimer <0)
                Shoot(player.weapon, mouseWorldPos - player.transform.position);
        }
        //move when shooting
        if (xInput != 0 || yInput != 0)
            player.SetVelocity(xInput, yInput, player.shootMoveSpeed, player.shootMoveSpeed, facingDir);
        else
            player.SetVelocity(0, 0);
    }
    private void Shoot(Weapon _weapon,Vector3 shootingDir)
    {
        if (_weapon.BulletCurrentCount >= _weapon.bulletCountPerShoot)
        {
            _weapon.ShootBullets(shootingDir);
        }
        else
        {
            _weapon.Load();
        }
    }
}
