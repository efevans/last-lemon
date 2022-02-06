using Assets.Scripts.Spawner;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public Spawner.Settings SpawnerSettings;
    public GoldManager.Settings GoldManagerSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(SpawnerSettings);
        Container.BindInstance(GoldManagerSettings);
    }
}