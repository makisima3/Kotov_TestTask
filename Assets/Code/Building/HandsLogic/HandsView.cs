using System;
using System.Collections.Generic;
using Code.Building.Enums;
using UnityEngine;

namespace Code.Building.HandsLogic
{
    
    public class HandsView : MonoBehaviour
    {
        private Dictionary<ItemType, GameObject> _typeToView;
        private ItemType _currentType;

        private void Awake()
        {
            _typeToView = new Dictionary<ItemType, GameObject>();
            GetViews(transform);

            foreach (var typeToView in _typeToView)
            {
                typeToView.Value.gameObject.SetActive(false);
            }
        }

        private void GetViews(Transform transform)
        {
            if(transform.TryGetComponent<HandsItemView>(out var view))
                _typeToView.Add(view.Type, view.gameObject);
            
            
            foreach (Transform child in transform)
            {
                GetViews(child);
            }
        }

        public void ShowItem(ItemType type)
        {
            Hide();
            _currentType = type;
            _typeToView[_currentType].SetActive(true);
        }

        public void Hide()
        {
            if(_currentType == ItemType.None)
                return;
            
            _typeToView[_currentType].SetActive(false);
            _currentType = ItemType.None;
        }
    }
}