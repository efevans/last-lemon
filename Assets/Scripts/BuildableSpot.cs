using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableSpot : MonoBehaviour
{
    private TowerDatabase _towerDatabase;
    private Building.Factory _buildingFactory;
    private GoldManager _goldManager;

    [Inject]
    public void Construct(TowerDatabase towerDatabase, Building.Factory towerFactory, GoldManager goldManager)
    {
        _towerDatabase = towerDatabase;
        _buildingFactory = towerFactory;
        _goldManager = goldManager;
    }

    private void OnMouseDown()
    {
        if (_goldManager.Gold >= 3)
        {
            _buildingFactory.Create(_towerDatabase.GetTower("Axe"), transform.position);
            _goldManager.SpendGold(3);
            Destroy(gameObject);
        }
    }
}
