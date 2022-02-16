using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Database", menuName = "Tower/New Tower Database")]
public class TowerDatabase : ScriptableObject
{
    public List<Tower> Towers;

    public Tower GetTower(string name)
    {
        var tower = Towers.Find(c => c.Name == name);

        if (tower == null)
        {
            Debug.LogError($"Could not find tower {name}");
        }

        return tower;
    }
}
