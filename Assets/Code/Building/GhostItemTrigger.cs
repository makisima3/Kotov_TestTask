using System;
using UnityEngine;

namespace Code.Building
{
    public class GhostItemTrigger : MonoBehaviour
    {
        private int _collisionCount;
        private LayerMask _exceptLayers;
        public int CollisionCount => _collisionCount;

        public void SetLayers(LayerMask layerMask) => _exceptLayers = layerMask;

        private void OnTriggerEnter(Collider other)
        {
            if (other.isTrigger || _exceptLayers == (_exceptLayers | (1 << other.transform.gameObject.layer)))
                return;
                
            _collisionCount++;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.isTrigger || _exceptLayers == (_exceptLayers | (1 << other.transform.gameObject.layer)))
                return;
                
            _collisionCount--;
        }
    }
}