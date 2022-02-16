using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower/New Tower")]
public class Tower : ScriptableObject
{
    public string Name;
    public TowerController TowerController;
    public Sprite Icon;
    public int Price;
}
