using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public GameObject ProjectilePrefab;
    public GameObject TowerPrefab;
    public GameObject EnemyPrefab;
    public GameObject Waypoint;

    public GoldManager GoldManager;

    public override void InstallBindings()
    {
        Container.BindFactory<Vector2, Transform, float, Projectile, Projectile.Factory>()
            .FromComponentInNewPrefab(ProjectilePrefab)
            .WithGameObjectName("Projectile")
            .UnderTransformGroup("Projectiles");

        Container.BindFactory<Vector2, Tower, Tower.Factory>()
            .FromComponentInNewPrefab(TowerPrefab)
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