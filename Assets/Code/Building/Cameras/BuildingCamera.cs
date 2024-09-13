using System;
using Code.Building.Enums;
using Code.Player.Configs;
using UnityEngine;
using Zenject;

namespace Code.Building.Cameras
{
    public class BuildingCamera : MonoBehaviour
    {
        [Inject] private PlayerActionConfig playerActionConfig;
        [Inject] private BuildingsConfig buildingsConfig;
        [Inject] private GhostItem ghostItem;

        [SerializeField] private LayerMask ghostMask;
        
        private Camera _camera;
        private LayerMask _buildingMask;
        private bool _isActive;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void Activate(ItemType itemType)
        {
            _isActive = true;
            _buildingMask = buildingsConfig.GetBuildingData(itemType).ValidBuildLayers;
        }

        public void Deactivate()
        {
            _isActive = false;
            _buildingMask = new LayerMask();
        }

        private void Update()
        {
            if (!_isActive)
                return;

            var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            var isHit = Physics.Raycast(ray, out var hit, playerActionConfig.MaxBuildDistance, ghostMask, QueryTriggerInteraction.Ignore);

            var position = ray.GetPoint(playerActionConfig.MaxBuildDistance);
            var onValidSurface = false; 

            if (isHit)
            {
                position = hit.point;
                onValidSurface = _buildingMask == (_buildingMask | (1 << hit.transform.gameObject.layer));
                
                ghostItem.RotateByNormal(hit.normal);
            }
            
            ghostItem.Move(position);
            ghostItem.Visualize(onValidSurface);
        }
    }
}