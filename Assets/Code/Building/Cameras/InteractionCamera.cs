using System;
using Code.Building.Interactables;
using Code.Player.Configs;
using UnityEngine;
using Zenject;

namespace Code.Building.Cameras
{
    public class InteractionCamera : MonoBehaviour
    {
        [Inject] private PlayerActionConfig playerActionConfig;
        
        private Interactable _currentInteractable;
        private bool _isActive;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;

            Activate();
        }

        public void Activate()
        {
            _isActive = true;
        }
        
        public void Deactivate()
        {
            _isActive = false;
        }

        private void Update()
        {
            if(_currentInteractable != null && Input.GetMouseButtonDown(0))
                _currentInteractable.Interact();
            
            if (_isActive)
            {
                var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));

                if (Physics.Raycast(ray, out var hit, playerActionConfig.InteractDistance))
                {
                    if (hit.transform.TryGetComponent<Interactable>(out var interactable))
                    {
                        if(_currentInteractable == interactable)
                            return;
                                
                        if(_currentInteractable != null)
                            _currentInteractable.Select(false);
                        
                        _currentInteractable = interactable;
                        _currentInteractable.Select(true);
                        
                        return;
                    }
                }
            }

            if(_currentInteractable == null)
                return;
            
            _currentInteractable.Select(false);
            _currentInteractable = null;
        }
    }
}