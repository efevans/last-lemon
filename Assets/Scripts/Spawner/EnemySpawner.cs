using Assets.Scripts.Spawner.State;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemyUnit.Factory EnemyFactory;
        [HideInInspector]
        public Settings SpawnerSettings;

        private SpawnState _state;

        public SpawnGroupHelper SpawnGroupHelperM;

        public List<EnemyUnit> Enemies { get; private set; }

        [Inject]
        public void Construct(EnemyUnit.Factory factory, Settings settings)
        {
            EnemyFactory = factory;
            SpawnerSettings = settings;
        }


        private void OnEnable()
        {
            SetSpawnState(new NotSpawningState(this));
        }

        public void StartRound()
        {
            RemoveEnemies();
            Enemies = new List<EnemyUnit>();
            SpawnGroupHelperM = new SpawnGroupHelper(SpawnerSettings.SpawnGroups);
            _state.StartRound();
        }

        private void RemoveEnemies()
        {
            if (Enemies == null)
                return;

            foreach (var enemy in Enemies)
            {
                if (enemy != null)
                {
                    Destroy(enemy);
                }
            }
        }

        public void StopSpawning()
        {
            _state.StopSpawning();
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
            public List<SpawnGroup> SpawnGroups;
        }

        [Serializable]
        public class SpawnGroup
        {
            public Enemy Enemy;
            public int Count;
        }

        public class SpawnGroupHelper
        {
            private readonly List<SpawnGroup> _spawnGroups;
            private SpawnGroup CurrentSpawnGroup => _spawnGroups.ElementAt(_currentSpawnGroupIndex);
            private int _currentSpawnGroupCount = 0;
            private int _currentSpawnGroupIndex = 0;

            public SpawnGroupHelper(List<SpawnGroup> spawnGroups)
            {
                _spawnGroups = spawnGroups;
            }

            public bool SpawningIsFinished
            {
                get
                {
                    if (_currentSpawnGroupIndex + 1 >= _spawnGroups.Count
                        && _currentSpawnGroupCount >= CurrentSpawnGroup.Count)
                    {
                        return true;
                    }
                    return false;
                }
            }

            public Enemy GetNextEnemy()
            {
                if (_currentSpawnGroupCount >= CurrentSpawnGroup.Count)
                {
                    _currentSpawnGroupIndex++;
                    _currentSpawnGroupCount = 0;
                }
                _currentSpawnGroupCount++;
                return CurrentSpawnGroup.Enemy;
            }
        }
    }
}