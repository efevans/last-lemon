using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Add Axe Tower/Behavior")]
public class AddAxeTowerBehavior : UpgradeBehavior
{
    private TowersManager _towersManager;

    [Inject]
    public void Construct(TowersManager towersManager)
    {
        _towersManager = towersManager;
    }

    public override void Apply()
    {
        _towersManager.EnableTower("Axe");
    }
}
