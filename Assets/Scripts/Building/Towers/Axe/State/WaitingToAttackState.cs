using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe.State
{
    public class WaitingToAttackState : AxeState
    {
        public WaitingToAttackState(AxeTowerStateController controller) : base(controller)
        {
        }

        public override void Update(Building building)
        {
            int targets = 0;

            foreach (var enemy in building.EnemyDetection.EnemiesInRange)
            {
                building.ProjectileBuilderFactory.Create()
                    .SetPosition(building.transform.position)
                    .SetTarget(enemy)
                    .SetSprite(_controller.TowerStatistics.Sprite)
                    .SetDamage(_controller.TowerStatistics.Damage)
                    .SetSpeed(_controller.TowerStatistics.ProjectileSpeed)
                    .Build();

                targets++;
                if (targets >= _controller.TowerStatistics.TargetCount)
                {
                    break;
                }
            }

            if (targets > 0)
            {
                building.AudioSource.PlayOneShot(_controller.TowerStatistics.OnShoot);
            }

            _controller.SetState(new CooldownState(_controller), building);
        }
    }
}