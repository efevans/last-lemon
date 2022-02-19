using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStatistics
{
    public float Cooldown;
    public float Damage;
    public float Range;
    public float ProjectileSpeed;
    public Sprite Sprite;

    public TowerStatistics(TowerBaseSettings settings)
    {
        Cooldown = settings.Cooldown;
        Damage = settings.Damage;
        Range = settings.Range;
        ProjectileSpeed = settings.ProjectileSpeed;
        Sprite = settings.Sprite;
    }
}
