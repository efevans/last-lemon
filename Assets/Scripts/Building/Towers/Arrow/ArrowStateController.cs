using Assets.Scripts.Building.Towers.Arrow.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow
{
    public class ArrowStateController : TowerStateController
    {
        private ArrowControlState _state;
        public ArrowSettings Settings;

        public ArrowStateController(ArrowSettings settings, Building building)
        {
            Settings = settings;
            SetState(new WaitingToAttackState(this), building);
        }

        public override void Update(Building building)
        {
            _state.Update(building);
        }

        public void SetState(ArrowControlState state, Building building)
        {
            _state = state;
            _state.Start(building);
        }
    }
}