using Assets.Scripts.Building.Towers.Arrow.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building.Towers.Arrow
{
    [CreateAssetMenu(fileName = "Arrow Controller", menuName = "Tower/Arrow/Arrow Controller")]
    public class ArrowController : TowerController
    {
        public TowerBaseSettings Settings;

        public override void Setup(Building building)
        {
            building.TowerStateController = new ArrowStateController(Settings, building);
        }
    }
}