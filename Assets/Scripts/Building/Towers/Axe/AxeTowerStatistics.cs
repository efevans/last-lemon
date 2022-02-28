using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTowerStatistics : TowerStatistics
{
    public int TargetCount;

    public AxeTowerStatistics(AxeSettings settings) : base(settings)
    {
        TargetCount = settings.TargetCount;
    }
}
