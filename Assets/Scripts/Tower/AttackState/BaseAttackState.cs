using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttackState
{
    protected Tower Tower;

    public BaseAttackState(Tower tower)
    {
        Tower = tower;
    }

    public virtual void Start() { }

    public virtual void OnUpdate() { }
}
