using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow.State
{
    public abstract class ArrowControlState
    {
        protected ArrowStateController _controller;

        public ArrowControlState(ArrowStateController controller)
        {
            _controller = controller;
        }

        public virtual void Start(Building building) { }
        public virtual void Update(Building building) { }
    }
}