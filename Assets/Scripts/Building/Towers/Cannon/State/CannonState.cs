namespace Assets.Scripts.Building.Towers.Cannon.State
{
    public class CannonState : ITowerState
    {
        protected CannonTowerStateController _controller;

        public CannonState(CannonTowerStateController controller)
        {
            _controller = controller;
        }

        public virtual void Start(Building building) { }
        public virtual void Update(Building building) { }
    }
}