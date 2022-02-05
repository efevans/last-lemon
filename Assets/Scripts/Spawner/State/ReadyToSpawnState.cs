namespace Assets.Scripts.Spawner.State
{
    public class ReadyToSpawnState : SpawnState
    {
        public ReadyToSpawnState(Spawner spawner) : base(spawner)
        {
        }

        public override void OnUpdate()
        {
            _spawner.EnemyFactory.Create(_spawner.transform.position);
            _spawner.SetSpawnState(new SpawnIntervalState(_spawner));
        }
    }
}