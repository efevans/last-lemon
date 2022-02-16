using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableSpot : MonoBehaviour
{
    private Building.Factory _buildingFactory;
    private GoldManager _goldManager;

    [SerializeField]
    private PopulateBuildableChoice _selectionBackground;

    [Inject]
    public void Construct(
        Building.Factory towerFactory,
        GoldManager goldManager)
    {
        _buildingFactory = towerFactory;
        _goldManager = goldManager;
    }

    private void OnMouseDown()
    {
        //if (_goldManager.Gold >= 3)
        //{
        //    _buildingFactory.Create(_towerDatabase.GetTower("Axe"), transform.position);
        //    _goldManager.SpendGold(3);
        //    Destroy(gameObject);
        //}

        ExpandSelection();
    }

    private void ExpandSelection()
    {
        _selectionBackground.Setup(OnSelectTower);
    }

    private void OnSelectTower(Tower tower)
    {
        if (_goldManager.Gold >= 3)
        {
            _buildingFactory.Create(tower, transform.position);
            _goldManager.SpendGold(3);
            Destroy(gameObject);
        }
    }
}
