using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawner.State
{
    public class SpawnIntervalState : SpawnState
    {
        public SpawnIntervalState(Spawner spawner) : base(spawner)
        {
        }

        public override void Start()
        {
            _spawner.StartCoroutine(ChangeToAttack());
        }

        private IEnumerator ChangeToAttack()
        {
            yield return new WaitForSeconds(0.8f);
            _spawner.SetSpawnState(new ReadyToSpawnState(_spawner));
        }
    }
}