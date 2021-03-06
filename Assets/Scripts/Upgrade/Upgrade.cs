using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/New Upgrade")]
public class Upgrade : ScriptableObject
{
    public enum StartingStatusE
    {
        Available,
        Unavailable,
    }

    public Sprite Icon;
    public UpgradeBehavior Behavior;
    [Range(1, 10)]
    public int Weight = 1;
    public StartingStatusE StartingStatus;
}
