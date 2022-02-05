namespace Assets.Scripts.Spawner.State
{
    public abstract class SpawnState
    {
        protected Spawner _spawner;

        public SpawnState(Spawner spawner)
        {
            _spawner = spawner;
        }

        public virtual void Start() { }

        public virtual void OnUpdate() { }
    }
}