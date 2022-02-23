using Assets.Scripts.Building;
using Assets.Scripts.Spawner;
using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject ProjectilePrefab;
    public GameObject BuildingPrefab;
    public GameObject BuildableChoicePrefab;
    public GameObject EnemyPrefab;
    public GameObject Waypoint;

    public TowerDatabase TowerDatabase;
    public UpgradeDatabase UpgradeDatabase;

    public GoldManager GoldManager;
    public Grid Grid;
    public Spawner Spawner;

    public EnableTowerBehavior AddAxeTowerBehavior;
    public AddDamageBehavior AddTwoDamageBehavior;
    public ReduceTowerCostBehavior ReduceArrowTowerCostByOneBehavior;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameController>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<TowersManager>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<TowerDatabase>()
            .FromInstance(TowerDatabase);

        Container.BindInterfacesAndSelfTo<UpgradesManager>()
            .FromNew()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<UpgradeDatabase>()
            .FromInstance(UpgradeDatabase);

        Container.BindFactory<Vector2, Transform, Sprite, float, float, Projectile, Projectile.Factory>()
            .FromComponentInNewPrefab(ProjectilePrefab)
            .WithGameObjectName("Projectile")
            .UnderTransformGroup("Projectiles");

        Container.BindFactory<GameObject, TowerSpecification, Action<TowerSpecification>, BuildableChoice, BuildableChoice.Factory>()
            .FromComponentInNewPrefab(BuildableChoicePrefab);

        Container.BindFactory<Tower, Vector2, Building, Building.Factory>()
            .FromComponentInNewPrefab(BuildingPrefab)
            .WithGameObjectName("Tower")
            .UnderTransformGroup("Towers");

        Container.BindFactory<Enemy, Vector2, EnemyUnit, EnemyUnit.Factory>()
            .FromComponentInNewPrefab(EnemyPrefab)
            .WithGameObjectName("Enemy")
            .UnderTransformGroup("Enemies");

        Container.BindInterfacesAndSelfTo<Waypoint>()
            .FromComponentsOn(Waypoint)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<GoldManager>()
            .FromInstance(GoldManager)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Grid>()
            .FromInstance(Grid)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Spawner>()
            .FromInstance(Spawner)
            .AsSingle();

        Container.QueueForInject(AddAxeTowerBehavior);
        Container.QueueForInject(AddTwoDamageBehavior);
        Container.QueueForInject(ReduceArrowTowerCostByOneBehavior);

        InstallSignals();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignalWithInterfaces<ISignalGoldManager>();
        Container.DeclareSignalWithInterfaces<ISignalUpgradeProgress>();
        Container.DeclareSignal<SignalEnemyDeath>().OptionalSubscriber();
    }
}