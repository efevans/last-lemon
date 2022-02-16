using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade Database", menuName = "Upgrade/New Upgrade Database")]
public class UpgradeDatabase : ScriptableObject
{
    public List<Upgrade> Upgrades;
}
