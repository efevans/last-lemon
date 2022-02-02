using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildableSpot : MonoBehaviour
{
    private Tower.Factory _towerFactory;

    [Inject]
    public void Construct(Tower.Factory towerFactory)
    {
        _towerFactory = towerFactory;
    }

    private void OnMouseDown()
    {
        _towerFactory.Create(transform.position);
        Destroy(gameObject);
    }
}
