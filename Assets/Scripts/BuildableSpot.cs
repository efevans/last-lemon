using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableSpot : MonoBehaviour
{
    private Tower.Factory _towerFactory;
    private GoldManager _goldManager;

    [Inject]
    public void Construct(Tower.Factory towerFactory, GoldManager goldManager)
    {
        _towerFactory = towerFactory;
        _goldManager = goldManager;
    }

    private void OnMouseDown()
    {
        if (_goldManager.Gold >= 3)
        {
            _towerFactory.Create(transform.position);
            _goldManager.SpendGold(3);
            Destroy(gameObject);
        }
    }
}
