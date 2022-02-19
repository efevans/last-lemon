using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe.State
{
    public class WaitingToAttackState : AxeState
    {
        public WaitingToAttackState(AxeStateController controller) : base(controller)
        {
        }

        public override void Update(Building building)
        {
            foreach (var enemy in building.EnemyDetection.EnemiesInRange)
            {
                building.ProjectileFactory.Create(
                    building.transform.position,
                    enemy,
                    _controller.TowerStatistics.Sprite,
                    _controller.TowerStatistics.Damage,
                    _controller.TowerStatistics.ProjectileSpeed);
                _controller.SetState(new CooldownState(_controller), building);
            }
        }
    }
}