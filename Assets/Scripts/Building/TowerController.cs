using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public abstract class TowerController : ScriptableObject
    {
        public virtual void DoStart(Building building) { }
        public virtual void DoUpdate(Building building) { }
    }
}