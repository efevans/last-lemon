using Assets.Scripts.Building.Towers.Axe.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe
{
    public class AxeStateController : TowerStateController
    {
        public AxeSettings Settings;
        private AxeState _state;

        public AxeStateController(AxeSettings settings, Building building)
        {
            Settings = settings;
            SetState(new WaitingToAttackState(this), building);
        }

        public override void Update(Building building)
        {
            _state.Update(building);
        }

        public void SetState(AxeState state, Building building)
        {
            _state = state;
            _state.Start(building);
        }
    }
}