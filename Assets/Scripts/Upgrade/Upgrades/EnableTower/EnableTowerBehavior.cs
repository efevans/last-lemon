using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Enable Tower/Behavior")]
public class EnableTowerBehavior : UpgradeBehavior
{
    private TowersManager _towersManager;
    private UpgradesManager _upgradesManager;
    private UpgradeDatabase _upgradeDatabase;

    [SerializeField]
    private Tower _tower;

    [SerializeField]
    private List<Upgrade> SecondaryTowerUpgrades;

    [Inject]
    public void Construct(TowersManager towersManager, UpgradesManager upgradesManager, UpgradeDatabase upgradeDatabase)
    {
        _towersManager = towersManager;
        _upgradesManager = upgradesManager;
        _upgradeDatabase = upgradeDatabase;
    }

    public override void Apply()
    {
        _towersManager.EnableTower(_tower);

        foreach (var secUpgrade in SecondaryTowerUpgrades)
        {
            _upgradesManager.MakeUpgradeAvailable(secUpgrade);
        }

        var enableCannonUpgrade = _upgradeDatabase.Upgrades.Single(u =>
        {
            if (u.Behavior is EnableTowerBehavior behavior)
                if (behavior._tower.Name == _tower.Name)
                    return true;
            return false;
        });

        _upgradesManager.MakeUpgradeUnavailable(enableCannonUpgrade);
    }
}
