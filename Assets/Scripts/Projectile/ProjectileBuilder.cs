using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectileBuilder
{
    private readonly Projectile.Factory _projectileFactory;
    private Projectile _projectile;

    [Inject]
    public ProjectileBuilder(Projectile.Factory factory)
    {
        _projectileFactory = factory;
        _projectile = factory.Create();
    }

    public ProjectileBuilder SetSprite(Sprite sprite)
    {
        _projectile.SpriteRenderer.sprite = sprite;
        return this;
    }

    public ProjectileBuilder SetPosition(Vector2 position)
    {
        _projectile.transform.position = position;
        return this;
    }

    public ProjectileBuilder SetTarget(Transform target)
    {
        _projectile.Target = target;
        return this;
    }

    public ProjectileBuilder SetDamage(float damage)
    {
        _projectile.Damage = damage;
        return this;
    }

    public ProjectileBuilder SetSpeed(float speed)
    {
        _projectile.Speed = speed;
        return this;
    }

    public ProjectileBuilder SetArea(float area)
    {
        _projectile.Area = area;
        return this;
    }

    public Projectile Build()
    {
        var finishedProjectile = _projectile;
        _projectile = _projectileFactory.Create();
        return finishedProjectile;
    }

    public class Factory : PlaceholderFactory<ProjectileBuilder> { }
}
