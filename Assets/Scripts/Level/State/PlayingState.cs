using Assets.Scripts.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level.State
{
    public class PlayingState : LevelState
    {
        public PlayingState(LevelController controller) : base(controller)
        {
        }

        public override void OnLoss()
        {
            _controller.Spawner.StopSpawning();
            _controller.OverlayInstructions.FadeIn();
            _controller.TowersManager.UnbuildBuildings();

            _controller.SetState(new WaitingToStart(_controller));
        }
    }
}