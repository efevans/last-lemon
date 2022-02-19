using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeBehavior : ScriptableObject
{
    public abstract void Apply();
    public virtual void ApplyTo(TowerStatistics statistics) { }
}
