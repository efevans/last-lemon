using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawner.State
{
    public class SpawnIntervalState : SpawnState
    {
        private Coroutine ChangingToAttack;

        public SpawnIntervalState(EnemySpawner spawner) : base(spawner)
        {
        }

        public override void Start()
        {
            ChangingToAttack = _spawner.StartCoroutine(ChangeToAttack());
        }

        private IEnumerator ChangeToAttack()
        {
            yield return new WaitForSeconds(0.8f);
            _spawner.SetSpawnState(new ReadyToSpawnState(_spawner));
        }

        public override void StopSpawning()
        {
            _spawner.StopCoroutine(ChangingToAttack);
            _spawner.SetSpawnState(new NotSpawningState(_spawner));
        }
    }
}