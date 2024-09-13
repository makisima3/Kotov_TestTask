using Code.Building.Enums;
using Code.Building.HandsLogic;
using Code.Building.Interactables;
using UnityEngine;
using Zenject;

namespace Code.Building
{
    public class PlacedItem : Interactable
    {
        [Inject] protected Hands hands;
        
        protected ItemType _itemType;

        public ItemType ItemType => _itemType;

        
        public void Init(ItemType itemType, Vector3 position, Quaternion rotation)
        {
            _itemType = itemType;

            transform.position = position;
            transform.rotation = rotation;
        }
        
        public override void Interact()
        {
            Take();
        }

        protected virtual void Take()
        {
            hands.Take(this);
            
            Destroy(gameObject);
        }
    }
}