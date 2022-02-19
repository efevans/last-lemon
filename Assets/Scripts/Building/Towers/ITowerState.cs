using Assets.Scripts.Building;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerState
{
    public void Start(Building building);
    public void Update(Building building);
}
