using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public abstract class TowerStateController
    {
        public virtual void Start(Building building) { }
        public virtual void Update(Building building) { }
    }
}