using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public abstract class TowerController : ScriptableObject
    {
        public virtual void Setup(Building building) { }
    }
}