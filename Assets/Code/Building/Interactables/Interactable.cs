using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Building.Interactables
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private Outline outline;

        protected virtual void Awake()
        {
            outline.enabled = false;
        }

        public void Select(bool value)
        {
            outline.enabled = value;
        }

        public abstract void Interact();
    }
}