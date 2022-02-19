using Assets.Scripts.Building.Towers.Axe.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe
{
    public class AxeStateController : BasicTowerStateController
    {
        public AxeStateController(TowerBaseSettings settings, Building building) : base(settings, building)
        {
        }

        public override ITowerState StartState()
        {
            return new WaitingToAttackState(this);
        }
    }
}