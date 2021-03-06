using Assets.Scripts.Building;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableSpot : MonoBehaviour
{
    private TowersManager _towersManager;
    private Building.Factory _buildingFactory;
    private GoldManager _goldManager;
    private UpgradesManager _upgradesManager;

    [SerializeField]
    private PopulateBuildableChoice _selectionBackground;

    [Inject]
    public void Construct(
        [InjectOptional]Vector2? spawnLocation,
        TowersManager towersManager,
        Building.Factory towerFactory,
        GoldManager goldManager,
        UpgradesManager upgradesManager)
    {
        if (spawnLocation != null)
        {
            transform.position = spawnLocation.Value;
        }
        _towersManager = towersManager;
        _buildingFactory = towerFactory;
        _goldManager = goldManager;
        _upgradesManager = upgradesManager;
    }

    private void OnMouseDown()
    {
        ExpandSelection();
    }

    private void ExpandSelection()
    {
        _selectionBackground.Setup(OnSelectTower);
    }

    private void OnSelectTower(TowerSpecification towerSpecification)
    {
        if (_goldManager.Gold >= towerSpecification.Price)
        {
            var building = _buildingFactory.Create(towerSpecification.Tower, transform.position);
            _towersManager.RegisterBuiltBuilding(building);
            _upgradesManager.ApplyUpgradesTo(building);
            _goldManager.SpendGold(towerSpecification.Price);
            Destroy(gameObject);
        }
    }

    public class Factory : PlaceholderFactory<Vector2, BuildableSpot> { }
}
