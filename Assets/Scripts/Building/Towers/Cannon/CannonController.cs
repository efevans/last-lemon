using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Cannon
{
    [CreateAssetMenu(fileName = "Cannon Controller", menuName = "Tower/Cannon/Cannon Controller")]
    public class CannonController : TowerController
    {
        public CannonSettings Settings;

        public override void Setup(Building building)
        {
            building.TowerStateController = new CannonTowerStateController(Settings, building);
        }
    }
}