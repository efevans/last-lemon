using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TowersManager : IInitializable
{
    private readonly TowerDatabase _towerDatabase;
    private Dictionary<Tower, TowerSpecification> _towerSpecifications;
    private List<Building> _buildings;

    private static readonly List<string> DefaultTowers = new List<string>() { "Arrow" };

    [Inject]
    public TowersManager(TowerDatabase towerDatabase)
    {
        _towerDatabase = towerDatabase;
    }

    public void Initialize()
    {
        _towerSpecifications = new Dictionary<Tower, TowerSpecification>();
        _buildings = new List<Building>();
        SeedTowerSpecifications();
        SeedBuildableTowers();
    }

    private void SeedTowerSpecifications()
    {
        foreach (Tower tower in _towerDatabase.Towers)
        {
            _towerSpecifications.Add(tower, new TowerSpecification(tower));
        }
    }

    public IReadOnlyList<TowerSpecification> GetTowerSpecifications()
    {
        return _towerSpecifications.Values.ToList().AsReadOnly();
    }

    public IReadOnlyList<TowerSpecification> GetBuildableTowers()
    {
        return _towerSpecifications.Values.Where(ts => ts.Buildable == true).ToList().AsReadOnly();
    }

    public void EnableTower(Tower tower)
    {
        _towerSpecifications[tower].Buildable = true;
    }

    public void SeedBuildableTowers()
    {
        foreach (var towerName in DefaultTowers)
        {
            var tower = _towerDatabase.GetTower(towerName);
            EnableTower(tower);
        }
    }

    public void RegisterBuiltBuilding(Building building)
    {
        _buildings.Add(building);
    }

    public IReadOnlyList<Building> GetBuildings()
    {
        return _buildings.AsReadOnly();
    }
}