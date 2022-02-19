using Assets.Scripts.Building.Towers.Arrow.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow
{
    public class ArrowStateController : BasicTowerStateController
    {
        public ArrowStateController(TowerBaseSettings settings, Building building) : base(settings, building)
        {
        }

        public override ITowerState StartState()
        {
            return new WaitingToAttackState(this);
        }
    }
}