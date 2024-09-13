using System;
using Code.Building.Cameras;
using Code.Player.Configs;
using UnityEngine;
using Zenject;

namespace Code.Building.HandsLogic
{
    public class Hands : MonoBehaviour
    {
        [Inject] private DiContainer container;
        [Inject] private HandsView handsView;
        [Inject] private GhostItem ghostItem;
        [Inject] private BuildingCamera buildingCamera;
        [Inject] private BuildingsConfig buildingsConfig;
        [Inject] private InteractionCamera interactionCamera;

        private BuildingData _currentBuildingData;
        private bool _justTaken;
        
        public void Take(PlacedItem placedItem)
        {
            _currentBuildingData = buildingsConfig.GetBuildingData(placedItem.ItemType);
            
            handsView.ShowItem(_currentBuildingData.Type);
            ghostItem.Show(_currentBuildingData.GhostObject, _currentBuildingData.ValidContactLayers, _currentBuildingData.LootLikeNormal);
            buildingCamera.Activate(_currentBuildingData.Type);
            interactionCamera.Deactivate();

            _justTaken = true;
        }

        public void TryBuild()
        {
            if(!ghostItem.CanBePlaced || _currentBuildingData == null)
                return;

            var placedItem = container.InstantiatePrefabForComponent<PlacedItem>(_currentBuildingData.PlacedObject);
            placedItem.Init(_currentBuildingData.Type, ghostItem.ViewTransform.position, ghostItem.ViewTransform.rotation);
            
            handsView.Hide();
            ghostItem.Hide();
            buildingCamera.Deactivate();
            interactionCamera.Activate();

            _currentBuildingData = null;
        }

        private void Update()
        {
            if(!Input.GetMouseButtonDown(0))
                return;

            if (_justTaken)
            {
                _justTaken = false;
                return;
            }
            
            TryBuild();
        }
    }
}