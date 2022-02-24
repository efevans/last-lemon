namespace Assets.Scripts.Spawner.State
{
    public class ReadyToSpawnState : SpawnState
    {
        public ReadyToSpawnState(EnemySpawner spawner) : base(spawner)
        {
        }

        public override void OnUpdate()
        {
            if (!_spawner.SpawnGroupHelperM.SpawningIsFinished)
            {
                var nextEnemy = _spawner.SpawnGroupHelperM.GetNextEnemy();
                _spawner.EnemyFactory.Create(nextEnemy, _spawner.transform.position);
                _spawner.SetSpawnState(new SpawnIntervalState(_spawner));
            }
        }

        public override void StopSpawning()
        {
            _spawner.SetSpawnState(new NotSpawningState(_spawner));
        }
    }
}