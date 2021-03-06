using Assets.Scripts.Building;
using Assets.Scripts.Spawner;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public EnemySpawner.Settings SpawnerSettings;
    public GoldManager.Settings GoldManagerSettings;
    public AudioManager.Settings AudioManagerSettings;
    public Building.MySettings BuildingSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(SpawnerSettings);
        Container.BindInstance(GoldManagerSettings);
        Container.BindInstance(AudioManagerSettings);
        Container.BindInstance(BuildingSettings);
    }
}