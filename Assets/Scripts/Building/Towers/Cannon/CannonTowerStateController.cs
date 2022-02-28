using Assets.Scripts.Building;
using Assets.Scripts.Building.Towers.Cannon.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Cannon
{
    public class CannonTowerStateController : TowerStateController
    {
        private readonly CannonSettings _settings;
        public CannonTowerStatistics TowerStatistics;
        private ITowerState _state;

        public ITowerState StartState()
        {
            return new WaitingToAttackState(this);
        }

        public CannonTowerStateController(CannonSettings settings, Building building)
        {
            _settings = settings;
            TowerStatistics = new CannonTowerStatistics(_settings);
            building.SetRange(TowerStatistics.Range);
            SetState(StartState(), building);
        }

        public override void Update(Building building)
        {
            _state.Update(building);
        }

        public void SetState(ITowerState state, Building building)
        {
            _state = state;
            _state.Start(building);
        }

        public override void ApplyUpgrade(UpgradeBehavior upgrade)
        {
            upgrade.ApplyTo(TowerStatistics);
        }
    }
}