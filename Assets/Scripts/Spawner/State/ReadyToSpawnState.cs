namespace Assets.Scripts.Spawner.State
{
    public class ReadyToSpawnState : SpawnState
    {
        public ReadyToSpawnState(Spawner spawner) : base(spawner)
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
    }
}