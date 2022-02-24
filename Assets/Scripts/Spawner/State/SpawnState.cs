namespace Assets.Scripts.Spawner.State
{
    public abstract class SpawnState
    {
        protected EnemySpawner _spawner;

        public SpawnState(EnemySpawner spawner)
        {
            _spawner = spawner;
        }

        public virtual void Start() { }

        public virtual void OnUpdate() { }

        public virtual void StartRound() { }

        public virtual void StopSpawning() { }
    }
}