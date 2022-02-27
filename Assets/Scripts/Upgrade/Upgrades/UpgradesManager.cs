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
        HashSet<Upgrade> upgrades = new HashSet<Upgrade>();
        int totalWeight = _availableUpgrades.Sum(u => u.Weight);
        Debug.Log($"Total Weight {totalWeight}");

        for (int i = 0; i < 3; i++)
        {
            Upgrade tempUpgrade = null;
            bool upgradeFound = false;

            do
            {
                int rand = Random.Range(0, totalWeight) + 1;
                foreach (var upgrade in _availableUpgrades)
                {
                    rand -= upgrade.Weight;

                    if (rand <= 0)
                    {
                        tempUpgrade = upgrade;
                        break;
                    }
                }

                if (tempUpgrade != null && !upgrades.Contains(tempUpgrade))
                {
                    upgrades.Add(tempUpgrade);
                    upgradeFound = true;
                }

            } while (upgradeFound == false);
        }

        return upgrades.ToList();
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
