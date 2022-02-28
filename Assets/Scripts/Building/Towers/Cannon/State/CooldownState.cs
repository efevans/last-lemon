using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Cannon.State
{
    public class CooldownState : CannonState
    {
        public CooldownState(CannonTowerStateController controller) : base(controller)
        {
        }

        public override void Start(Building building)
        {
            building.StartCoroutine(ChangeToAttack(building));
        }

        private IEnumerator ChangeToAttack(Building building)
        {
            yield return new WaitForSeconds(_controller.TowerStatistics.Cooldown);
            _controller.SetState(new WaitingToAttackState(_controller), building);
        }
    }
}