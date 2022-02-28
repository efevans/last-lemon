using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Increase Axe Targets/Behavior")]
public class IncreaseAxeTargetsBehavior : UpgradeBehavior
{
    public int Amount;

    private TowersManager _towersManager;

    [Inject]
    public void Construct(TowersManager towersManager)
    {
        _towersManager = towersManager;
    }

    public override void Apply()
    {
        foreach (var tower in _towersManager.GetBuildings())
        {
            tower.ApplyUpgrade(this);
        }
    }

    public override void ApplyTo(TowerStatistics statistics)
    {
        if (statistics is AxeTowerStatistics axeStatistics)
        {
            axeStatistics.TargetCount += Amount;
        }
    }
}
