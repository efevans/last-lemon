using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe.State
{
    public abstract class AxeState : ITowerState
    {
        protected AxeStateController _controller;

        public AxeState(AxeStateController controller)
        {
            _controller = controller;
        }

        public virtual void Start(Building building) { }
        public virtual void Update(Building building) { }
    }
}