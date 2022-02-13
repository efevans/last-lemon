using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe
{
    [CreateAssetMenu(fileName = "Axe Settings", menuName = "Tower/Axe/Settings")]
    public class AxeSettings : ScriptableObject
    {
        public float Cooldown;
        public float Damage;
        public float ProjectileSpeed;
        public Sprite Sprite;
    }
}