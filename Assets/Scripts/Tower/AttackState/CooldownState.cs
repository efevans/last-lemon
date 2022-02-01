using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownState : AttackState
{
    public CooldownState(Tower tower) : base(tower)
    {
    }

    public override void Start()
    {
        _tower.StartCoroutine(ChangeToAttack());
    }

    private IEnumerator ChangeToAttack()
    {
        yield return new WaitForSeconds(0.8f);
        _tower.SetAttackState(new WaitingToAttackState(_tower));
    }
}
