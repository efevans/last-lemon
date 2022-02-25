using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Increase Attack Speed/Behavior")]
public class IncreaseAttackSpeedBehavior : UpgradeBehavior
{
    public float Percent;

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
        statistics.Cooldown *= ((100 - Percent) / 100f);
    }
}
