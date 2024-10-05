using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthControl : HealthControl
{
    public override void DeadCheck()
    {
        base.DeadCheck();
    }

    public override void GetHurt(float _damage)
    {
        base.GetHurt(_damage);
        UIControl.instance.UpdateHealth((int)_damage);
        if (currentHealth <= 0)
        { 
            GameControll.instance.GameOver();
            Player player = gameObject.GetComponent<Player>();
            player.StateMachine.ChangeState(player.DeadState);
        }
    }
    public void AddHealth(int _add)
    {
        if (currentHealth + _add < maxHealthValue)
        {
            currentHealth += _add;
            UIControl.instance.UpdateHealth(0, _add);
        }
        else
        {
            UIControl.instance.UpdateHealth(0, (int)(maxHealthValue - currentHealth));
            currentHealth = maxHealthValue;
        }
    }
    public void AddMaxHealth(int _add)
    {
        maxHealthValue += _add;
    }

    protected override void Start()
    {
        base.Start();
        UIControl.instance.SetHealth((int)maxHealthValue);
    }
}
