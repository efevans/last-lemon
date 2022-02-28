using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerStatistics : TowerStatistics
{
    public float Area;

    public CannonTowerStatistics(CannonSettings settings) : base(settings)
    {
        Area = settings.Area;
    }
}
