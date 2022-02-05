using Assets.Scripts.Spawner.State;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Spawner
{
    public class Spawner : MonoBehaviour
    {
        public Enemy.Factory EnemyFactory;
        public Settings SpawnerSettings;

        private SpawnState _state;

        public int RemainingSpawns;

        [Inject]
        public void Construct(Enemy.Factory factory, Settings settings)
        {
            EnemyFactory = factory;
            SpawnerSettings = settings;
        }

        private void Start()
        {
            RemainingSpawns = SpawnerSettings.UnitCount;
            SetSpawnState(new SpawnIntervalState(this));
        }

        private void Update()
        {
            _state.OnUpdate();
        }

        public void SetSpawnState(SpawnState state)
        {
            _state = state;
            _state.Start();
        }

        [Serializable]
        public class Settings
        {
            [Range(0, 100)]
            public int UnitCount;
        }
    }
}