using Assets.Scripts.Building;
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
        TowersManager towersManager,
        Building.Factory towerFactory,
        GoldManager goldManager,
        UpgradesManager upgradesManager)
    {
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

    private void OnSelectTower(Tower tower)
    {
        if (_goldManager.Gold >= tower.Price)
        {
            var building = _buildingFactory.Create(tower, transform.position);
            _towersManager.RegisterBuiltBuilding(building);
            _upgradesManager.ApplyUpgradesTo(building);
            _goldManager.SpendGold(tower.Price);
            Destroy(gameObject);
        }
    }
}
