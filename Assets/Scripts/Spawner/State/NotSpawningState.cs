using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spawner.State
{
    public class NotSpawningState : SpawnState
    {
        public NotSpawningState(EnemySpawner spawner) : base(spawner)
        {
        }

        public override void StartRound()
        {
            _spawner.SetSpawnState(new ReadyToSpawnState(_spawner));
        }
    }
}