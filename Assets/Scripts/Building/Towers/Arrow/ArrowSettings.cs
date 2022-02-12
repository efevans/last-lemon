using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow
{
    [CreateAssetMenu(fileName = "Arrow Settings", menuName = "Tower/Arrow/Settings")]
    public class ArrowSettings : ScriptableObject
    {
        public float Cooldown;
        public float Damage;
        public float ProjectileSpeed;
    }
}