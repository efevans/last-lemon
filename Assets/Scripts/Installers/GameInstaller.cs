using Assets.Scripts.Building;
using Assets.Scripts.Level;
using Assets.Scripts.Spawner;
using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject ProjectilePrefab;
    public GameObject BuildingPrefab;
    public GameObject BuildableLocation;
    public GameObject BuildableChoicePrefab;
    public GameObject EnemyPrefab;
    public GameObject Waypoint;

    public AudioSource AudioSource;

    public TowerDatabase TowerDatabase;
    public UpgradeDatabase UpgradeDatabase;

    public GoldManager GoldManager;
    public EnemySpawner Spawner;
    public Exit Exit;
    public OverlayInstructions OverlayInstructions;

    public EnableTowerBehavior AddAxeTowerBehavior;
    public AddFlatDamageBehavior AddTwoDamageBehavior;
    public ReduceTowerCostBehavior ReduceArrowTowerCostByOneBehavior;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioSource>()
            .FromInstance(AudioSource);

        Container.BindInterfacesAndSelfTo<AudioManager>()
            .AsSingle()
            .NonLazy();

        Container.BindInterfacesAndSelfTo<LevelController>()
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

        Container.BindFactory<Vector2, BuildableSpot, BuildableSpot.Factory>()
            .FromComponentInNewPrefab(BuildableLocation)
            .WithGameObjectName("BuildableLocation")
            .UnderTransformGroup("BuildableLocations");

        Container.BindInterfacesAndSelfTo<Waypoint>()
            .FromComponentsOn(Waypoint)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<GoldManager>()
            .FromInstance(GoldManager)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<Exit>()
            .FromInstance(Exit)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<OverlayInstructions>()
            .FromInstance(OverlayInstructions)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<EnemySpawner>()
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