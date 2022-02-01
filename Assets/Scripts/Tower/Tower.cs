using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour
{
    public Projectile.Factory ProjectileFactory { get; private set; }

    [SerializeField]
    public EnemyDetection EnemyDetection;

    private AttackState _attackState;

    [Inject]
    public void Construct(Projectile.Factory factory)
    {
        ProjectileFactory = factory;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetAttackState(new WaitingToAttackState(this));
    }

    // Update is called once per frame
    void Update()
    {
        _attackState.OnUpdate();
    }

    public void SetAttackState(AttackState attackState)
    {
        _attackState = attackState;
        _attackState.Start();
    }
}
