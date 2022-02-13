using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow.State
{
    public class WaitingToAttackState : ArrowControlState
    {
        public WaitingToAttackState(ArrowStateController controller) : base(controller)
        {
        }

        public override void Update(Building building)
        {
            if (building.EnemyDetection.TargetedEnemy != null)
            {
                building.ProjectileFactory.Create(
                    building.transform.position,
                    building.EnemyDetection.TargetedEnemy,
                    _controller.Settings.Sprite,
                    _controller.Settings.Damage,
                    _controller.Settings.ProjectileSpeed);
                _controller.SetState(new CooldownState(_controller), building);
            }
        }
    }
}