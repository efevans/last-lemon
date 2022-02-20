using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowersManager : IInitializable
{
    private readonly TowerDatabase _towerDatabase;
    private List<TowerSpecification> _towerSpecifications;
    private List<TowerSpecification> _buildableTowers;
    private List<Building> _buildings;

    private static readonly List<string> DefaultTowers = new List<string>() { "Arrow" };

    [Inject]
    public TowersManager(TowerDatabase towerDatabase)
    {
        _towerDatabase = towerDatabase;
    }

    public void Initialize()
    {
        _buildableTowers = new List<TowerSpecification>();
        _towerSpecifications = new List<TowerSpecification>();
        _buildings = new List<Building>();
        SeedTowerSpecifications();
        SeedBuildableTowers();
    }

    private void SeedTowerSpecifications()
    {
        foreach (Tower tower in _towerDatabase.Towers)
        {
            _towerSpecifications.Add(new TowerSpecification(tower));
        }
    }

    public IReadOnlyList<TowerSpecification> GetBuildableTowers()
    {
        return _buildableTowers.AsReadOnly();
    }

    public void EnableTower(string id)
    {
        if (!_buildableTowers.Exists(t => t.Tower.Name == id))
        {
            _buildableTowers.Add(new TowerSpecification(_towerDatabase.GetTower(id)));
        }
    }

    public void SeedBuildableTowers()
    {
        foreach (var tower in DefaultTowers)
        {
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
