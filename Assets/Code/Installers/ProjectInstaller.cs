using Code.Player.Configs;
using Code.Player.Data;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [Header("Objects")]
        [SerializeField] private PlayerDataHolder playerDataHolder;
        
        [Header("Configs")]
        [SerializeField] private PlayerActionConfig playerActionConfig;
        
        public override void InstallBindings()
        {
            //Objects
            Container.Bind<PlayerDataHolder>().FromInstance(playerDataHolder).AsSingle().NonLazy();
            
            //Configs
            Container.Bind<PlayerActionConfig>().FromInstance(playerActionConfig).AsSingle().NonLazy();
        }
    }
}