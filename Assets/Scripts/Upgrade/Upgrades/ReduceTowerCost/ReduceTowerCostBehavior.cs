using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Behavior", menuName = "Upgrade/Reduce Cost/Behavior")]
public class ReduceTowerCostBehavior : UpgradeBehavior
{
    public float Amount;

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
        var specification = _towersManager.GetTowerSpecifications().Where(t => t.Tower == _tower).Single();
        specification.Price -= 1;
    }
}
