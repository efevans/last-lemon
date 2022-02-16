using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowersManager : IInitializable
{
    private readonly TowerDatabase _towerDatabase;
    private List<Tower> _buildableTowers;

    private static readonly List<string> DefaultTowers = new List<string>() { "Arrow" };

    [Inject]
    public TowersManager(TowerDatabase towerDatabase)
    {
        _towerDatabase = towerDatabase;
    }

    public void Initialize()
    {
        _buildableTowers = new List<Tower>();
        SeedBuildableTowers();
    }

    public IReadOnlyList<Tower> GetBuildableTowers()
    {
        return _buildableTowers.AsReadOnly();
    }

    public void EnableTower(string id)
    {
        if (!_buildableTowers.Exists(t => t.Name == id))
        {
            _buildableTowers.Add(_towerDatabase.GetTower(id));
        }
    }

    public void SeedBuildableTowers()
    {
        foreach (var tower in DefaultTowers)
        {
            _buildableTowers.Add(_towerDatabase.GetTower(tower));
        }
    }
}
