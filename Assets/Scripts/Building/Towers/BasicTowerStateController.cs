using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicTowerStateController : TowerStateController
{
    private readonly TowerBaseSettings _settings;
    public TowerStatistics TowerStatistics;
    private ITowerState _state;

    public abstract ITowerState StartState();

    public BasicTowerStateController(TowerBaseSettings settings, Building building)
    {
        _settings = settings;
        TowerStatistics = new TowerStatistics(_settings);
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
        Debug.Log($"Damage before upgrade: {TowerStatistics.Damage}");
        upgrade.ApplyTo(TowerStatistics);
        Debug.Log($"Damage after upgrade: {TowerStatistics.Damage}");
    }
}
