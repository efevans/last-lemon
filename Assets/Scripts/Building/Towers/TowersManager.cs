using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TowersManager : IInitializable
{
    private readonly TowerDatabase _towerDatabase;
    private Dictionary<Tower, TowerSpecification> _towerSpecifications = new Dictionary<Tower, TowerSpecification>();
    private List<Building> _buildings = new List<Building>();

    private static readonly List<string> DefaultTowers = new List<string>() { "Arrow" };

    [Inject]
    public TowersManager(TowerDatabase towerDatabase)
    {
        _towerDatabase = towerDatabase;
    }

    public void Initialize()
    {
        SetDefaultState();
    }

    public void SetDefaultState()
    {
        UnbuildBuildings();
        _buildings.Clear();
        _towerSpecifications.Clear();
        SeedTowerSpecifications();
        SeedBuildableTowers();
    }

    public void UnbuildBuildings()
    {
        if (_buildings == null)
            return;

        foreach (var building in _buildings)
        {
            building.Unbuild();
        }
        _buildings.Clear();
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
