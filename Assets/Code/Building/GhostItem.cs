using System;
using System.Collections.Generic;
using Code.Player.Configs;
using UnityEngine;
using Zenject;

namespace Code.Building
{
    public class GhostItem : MonoBehaviour
    {
        private GhostItemTrigger _trigger;
        private List<MeshRenderer> _meshRenderers;
        private bool _onValidSurface;
        private bool _lookLikeNormal;

        
        public bool CanBePlaced => _trigger != null && _trigger.CollisionCount == 0 && _onValidSurface;
        public Transform ViewTransform => _trigger.transform;
        
        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if(_lookLikeNormal)
                return;
            
            var axis = Input.GetAxis("Mouse ScrollWheel");
            
            if(Mathf.Abs(axis) < 0.05f)
                return;

            var dir = axis > 0? 1 : -1; 
            _trigger.transform.rotation *= Quaternion.Euler(0f, 45f * dir, 0f);
        }

        private void GetMeshRenderers(Transform transform)
        {
            if (transform.TryGetComponent<MeshRenderer>(out var renderer))
                _meshRenderers.Add(renderer);

            foreach (Transform child in transform)
            {
                GetMeshRenderers(child);
            }
        }
        
        public void Show(GameObject prefab, LayerMask validLayers, bool lookLikeNormal)
        {
            var item = Instantiate(prefab, transform);

            _meshRenderers = new List<MeshRenderer>();
            GetMeshRenderers(item.transform);

            _lookLikeNormal = lookLikeNormal;
            
            _trigger = item.AddComponent<GhostItemTrigger>();
            _trigger.SetLayers(validLayers);
        }
        
        public void Hide()
        {
            if(_trigger != null)
                Destroy(_trigger.gameObject);
        }

        public void Visualize(bool onValidSurface)
        {
            _onValidSurface = onValidSurface;
            
            var color = CanBePlaced? Color.green : Color.red;
            color.a = 0.5f;
            
            _meshRenderers.ForEach(m => m.material.color = color);
        }

        public void Move(Vector3 position)
        {
            transform.position = position;
        }

        public void RotateByNormal(Vector3 normal)
        {
            if(!_lookLikeNormal)
                return;
            
            transform.forward = normal;
        }
    }
}