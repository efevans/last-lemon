using Assets.Scripts.Spawner.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Spawner
{
    public class Spawner : MonoBehaviour
    {
        private SpawnState _state;
        public Enemy.Factory EnemyFactory;

        [Inject]
        public void Construct(Enemy.Factory factory)
        {
            EnemyFactory = factory;
        }

        private void Start()
        {
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
    }
}