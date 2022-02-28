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
                building.ProjectileBuilderFactory.Create()
                    .SetPosition(building.transform.position)
                    .SetTarget(building.EnemyDetection.TargetedEnemy)
                    .SetSprite(_controller.TowerStatistics.Sprite)
                    .SetDamage(_controller.TowerStatistics.Damage)
                    .SetSpeed(_controller.TowerStatistics.ProjectileSpeed)
                    .Build();
                _controller.SetState(new CooldownState(_controller), building);
            }
        }
    }
}
