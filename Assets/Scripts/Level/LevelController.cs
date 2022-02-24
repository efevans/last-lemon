using Assets.Scripts.Level.State;
using Assets.Scripts.Spawner;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Assets.Scripts.Level
{
    public class LevelController : IInitializable, ITickable
    {
        public readonly Exit Exit;
        public readonly EnemySpawner Spawner;
        public readonly OverlayInstructions OverlayInstructions;
        public readonly TowersManager TowersManager;
        public readonly GoldManager GoldManager;

        private LevelState _state;

        public LevelController(Exit exit, EnemySpawner spawner, OverlayInstructions overlayInstructions,
            TowersManager towersManager, GoldManager goldManager)
        {
            Exit = exit;
            Spawner = spawner;
            OverlayInstructions = overlayInstructions;
            TowersManager = towersManager;
            GoldManager = goldManager;
        }

        public void Initialize()
        {
            Exit.SetOnLossCallback(OnLoss);
            SetState(new WaitingToStart(this));
        }

        private void OnLoss()
        {
            _state.OnLoss();
        }

        public void Tick()
        {
            _state.Update();
        }

        public void SetState(LevelState state)
        {
            _state = state;
            _state.Start();
        }
    }
}