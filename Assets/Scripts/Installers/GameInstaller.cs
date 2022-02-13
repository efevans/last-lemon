using Assets.Scripts.Building;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject ProjectilePrefab;
    public GameObject BuildingPrefab;
    public GameObject EnemyPrefab;
    public GameObject Waypoint;

    public TowerDatabase TowerDatabase;

    public GoldManager GoldManager;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TowerDatabase>()
            .FromInstance(TowerDatabase);

        Container.BindFactory<Vector2, Transform, Sprite, float, float, Projectile, Projectile.Factory>()
            .FromComponentInNewPrefab(ProjectilePrefab)
            .WithGameObjectName("Projectile")
            .UnderTransformGroup("Projectiles");

        Container.BindFactory<Tower, Vector2, Building, Building.Factory>()
            .FromComponentInNewPrefab(BuildingPrefab)
            .WithGameObjectName("Tower")
            .UnderTransformGroup("Towers");

        Container.BindFactory<Vector2, Enemy, Enemy.Factory>()
            .FromComponentInNewPrefab(EnemyPrefab)
            .WithGameObjectName("Enemy")
            .UnderTransformGroup("Enemies");

        Container.BindInterfacesAndSelfTo<Waypoint>()
            .FromComponentsOn(Waypoint)
            .AsSingle();

        Container.BindInterfacesAndSelfTo<GoldManager>()
            .FromInstance(GoldManager)
            .AsSingle();

        InstallSignals();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignalWithInterfaces<ISignalGoldManager>();
        Container.DeclareSignal<SignalEnemyDeath>().OptionalSubscriber();
    }
}