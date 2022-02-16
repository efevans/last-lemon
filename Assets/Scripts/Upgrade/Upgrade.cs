using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade/New Upgrade")]
public class Upgrade : ScriptableObject
{
    public Sprite Icon;
    public UpgradeBehavior Behavior;
}
