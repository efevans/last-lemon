using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpecification
{
    public Tower Tower;
    public int Price;
    public bool Buildable;

    public TowerSpecification(Tower tower)
    {
        Tower = tower;
        Price = Tower.Price;
        Buildable = false;
    }
}
