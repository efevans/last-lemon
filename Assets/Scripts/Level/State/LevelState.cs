using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level.State
{
    public class LevelState
    {
        protected LevelController _controller;

        public LevelState(LevelController controller)
        {
            _controller = controller;
        }

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void OnLoss() { }
    }
}