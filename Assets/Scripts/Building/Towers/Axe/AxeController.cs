using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Axe
{
    [CreateAssetMenu(fileName = "Axe Controller", menuName ="Tower/Axe/Axe Controller")]
    public class AxeController : TowerController
    {
        public AxeSettings Settings;

        public override void Setup(Building building)
        {
            building.SetRange(Settings.Range);
            building.TowerStateController = new AxeStateController(Settings, building);
        }

        public override void DoUpdate(Building building)
        {
            building.TowerStateController.Update(building);
        }
    }
}