using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class UpgradesManager : IInitializable
{
    private readonly UpgradeDatabase _upgradeDatabase;
    private List<Upgrade> _availableUpgrades;
    private List<Upgrade> _acquiredUpgrades;

    [Inject]
    public UpgradesManager(UpgradeDatabase upgradeDatabase)
    {
        _upgradeDatabase = upgradeDatabase;
    }

    public void Initialize()
    {
        _availableUpgrades = new List<Upgrade>();
        _acquiredUpgrades = new List<Upgrade>();
        SeedUpgrades();
    }

    public IReadOnlyList<Upgrade> GetAvailableUpgrades()
    {
        return _availableUpgrades.AsReadOnly();
    }

    public List<Upgrade> GetThreeRandomUpgrades()
    {
        return new List<Upgrade>()
        {
            _availableUpgrades.ElementAt(0),
            _availableUpgrades.ElementAt(1),
            _availableUpgrades.ElementAt(2),
        };
    }

    public void SeedUpgrades()
    {
        foreach (var upgrade in _upgradeDatabase.Upgrades)
        {
            _availableUpgrades.Add(upgrade);
        }
    }

    public void AcquireUpgrade(Upgrade upgrade)
    {
        upgrade.Behavior.Apply();
        _acquiredUpgrades.Add(upgrade);
    }

    public void ApplyUpgradesTo(Building building)
    {
        foreach (var upgrade in _acquiredUpgrades)
        {
            building.ApplyUpgrade(upgrade.Behavior);
        }
    }
}
