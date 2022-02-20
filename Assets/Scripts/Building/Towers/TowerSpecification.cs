using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpecification
{
    public Tower Tower;
    public int Price;

    public TowerSpecification(Tower tower)
    {
        Tower = tower;
        Price = Tower.Price;
    }
}
