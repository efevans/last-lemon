using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Cannon.State
{
    public class WaitingToAttackState : CannonState
    {
        public WaitingToAttackState(CannonTowerStateController controller) : base(controller)
        {
        }

        public override void Update(Building building)
        {
            if (building.EnemyDetection.TargetedEnemy != null)
            {
                building.ProjectileFactory.Create(
                    building.transform.position,
                    building.EnemyDetection.TargetedEnemy,
                    _controller.TowerStatistics.Sprite,
                    _controller.TowerStatistics.Damage,
                    _controller.TowerStatistics.ProjectileSpeed);
                _controller.SetState(new CooldownState(_controller), building);
            }
        }
    }
}
