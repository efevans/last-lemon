using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe.State
{
    public class CooldownState : AxeState
    {
        public CooldownState(AxeStateController controller) : base(controller)
        {
        }

        public override void Start(Building building)
        {
            building.StartCoroutine(ChangeToAttack(building));
        }

        private IEnumerator ChangeToAttack(Building building)
        {
            yield return new WaitForSeconds(_controller.Settings.Cooldown);
            _controller.SetState(new WaitingToAttackState(_controller), building);
        }
    }
}