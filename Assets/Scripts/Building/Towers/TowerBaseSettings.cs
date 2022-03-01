using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Base Settings", menuName = "Tower/Base Settings")]
public class TowerBaseSettings : ScriptableObject
{
    public float Cooldown;
    public float Damage;
    public float Range;
    public float ProjectileSpeed;
    public Sprite Sprite;
    public AudioClip OnShoot;
}
