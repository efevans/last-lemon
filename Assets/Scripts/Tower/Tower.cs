using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour
{
    public Projectile.Factory ProjectileFactory { get; private set; }

    [SerializeField]
    public EnemyDetection EnemyDetection;

    [Inject]
    public void Construct(Projectile.Factory factory)
    {
        ProjectileFactory = factory;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDetection.TargetedEnemy != null)
        {
            ProjectileFactory.Create(transform.position, EnemyDetection.TargetedEnemy);
        }
    }
}
