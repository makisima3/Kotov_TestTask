using System;
using Code.Building.Enums;
using UnityEngine;

namespace Code.Building
{
    public class InfinityItem : PlacedItem
    {
        [SerializeField] private ItemType type;

        protected override void Awake()
        {
            base.Awake();
            
            _itemType = type;
        }

        protected override void Take()
        {
            hands.Take(this);
        }
    }
}