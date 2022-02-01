using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackState
{
    protected Tower _tower;

    public AttackState(Tower tower)
    {
        _tower = tower;
    }

    public virtual void Start() { }

    public virtual void OnUpdate() { }
}
