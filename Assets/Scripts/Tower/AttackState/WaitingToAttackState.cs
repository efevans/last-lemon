using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingToAttackState : AttackState
{
    public WaitingToAttackState(Tower tower) : base(tower)
    {
    }

    public override void OnUpdate()
    {
        if (_tower.EnemyDetection.TargetedEnemy != null)
        {
            _tower.ProjectileFactory.Create(
                _tower.transform.position,
                _tower.EnemyDetection.TargetedEnemy,
                _tower.Damage);
            _tower.SetAttackState(new CooldownState(_tower));
        }
    }
}
