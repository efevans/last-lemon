using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Add Axe Tower/Behavior")]
public class EnableTowerBehavior : UpgradeBehavior
{
    private TowersManager _towersManager;
    [SerializeField]
    private Tower _tower;

    [Inject]
    public void Construct(TowersManager towersManager)
    {
        _towersManager = towersManager;
    }

    public override void Apply()
    {
        _towersManager.EnableTower(_tower);
    }
}
