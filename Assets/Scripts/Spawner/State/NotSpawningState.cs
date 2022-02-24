using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Spawner.EnemySpawner;

namespace Assets.Scripts.Spawner.State
{
    public class NotSpawningState : SpawnState
    {
        public NotSpawningState(EnemySpawner spawner) : base(spawner)
        {
        }

        public override void StartRound()
        {
            _spawner.RemoveEnemies();
            _spawner.Enemies.Clear();
            _spawner.SpawnGroupHelperM = new SpawnGroupHelper(_spawner.SpawnerSettings.SpawnGroups);
            _spawner.SetSpawnState(new ReadyToSpawnState(_spawner));
        }
    }
}