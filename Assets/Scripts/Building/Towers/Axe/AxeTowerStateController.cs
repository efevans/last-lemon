using Assets.Scripts.Building;
using Assets.Scripts.Building.Towers.Axe.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTowerStateController : TowerStateController
{
    private readonly AxeSettings _settings;
    public AxeTowerStatistics TowerStatistics;
    private ITowerState _state;

    public ITowerState StartState()
    {
        return new WaitingToAttackState(this);
    }

    public AxeTowerStateController(AxeSettings settings, Building building)
    {
        _settings = settings;
        TowerStatistics = new AxeTowerStatistics(_settings);
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
