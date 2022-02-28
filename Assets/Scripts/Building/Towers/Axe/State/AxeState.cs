using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe.State
{
    public abstract class AxeState : ITowerState
    {
        protected AxeTowerStateController _controller;

        public AxeState(AxeTowerStateController controller)
        {
            _controller = controller;
        }

        public virtual void Start(Building building) { }
        public virtual void Update(Building building) { }
    }
}