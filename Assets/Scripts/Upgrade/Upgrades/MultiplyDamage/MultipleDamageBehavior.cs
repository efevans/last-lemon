using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Multiply Damage/Behavior")]
public class MultipleDamageBehavior : UpgradeBehavior
{
    public float Amount;

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
        statistics.Damage *= Amount;
    }
}
