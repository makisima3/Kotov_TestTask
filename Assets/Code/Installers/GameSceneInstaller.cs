using Code.Building;
using Code.Building.Cameras;
using Code.Building.HandsLogic;
using Code.Player.Configs;
using Code.Player.Data;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Header("Objects")]
        [SerializeField] private GhostItem ghostItem;
        [SerializeField] private Hands hands;
        [SerializeField] private HandsView handsView;
        [SerializeField] private BuildingCamera buildingCamera;
        [SerializeField] private InteractionCamera interactionCamera;
        
        [Header("Configs")]
        [SerializeField] private BuildingsConfig buildingsConfig;
        
        public override void InstallBindings()
        {
            //Objects
            Container.Bind<GhostItem>().FromInstance(ghostItem).AsSingle().NonLazy();
            Container.Bind<Hands>().FromInstance(hands).AsSingle().NonLazy();
            Container.Bind<HandsView>().FromInstance(handsView).AsSingle().NonLazy();
            Container.Bind<BuildingCamera>().FromInstance(buildingCamera).AsSingle().NonLazy();
            Container.Bind<InteractionCamera>().FromInstance(interactionCamera).AsSingle().NonLazy();
            
            //Configs
            Container.Bind<BuildingsConfig>().FromInstance(buildingsConfig).AsSingle().NonLazy();
        }
    }
}