using Assets.Scripts.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Level.State
{
    public class WaitingToStart : LevelState
    {
        public WaitingToStart(LevelController controller) : base(controller)
        {
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _controller.Spawner.StartRound();
                _controller.OverlayInstructions.Hide();
                _controller.TowersManager.SetDefaultState();
                _controller.UpgradesManager.SetDefaultState();
                _controller.GoldManager.ResetToStartingGold();
                _controller.Exit.ResetExit();

                _controller.SetState(new PlayingState(_controller));
            }
        }
    }
}