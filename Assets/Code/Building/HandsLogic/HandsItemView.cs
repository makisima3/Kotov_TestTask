using Code.Building.Enums;
using UnityEngine;

namespace Code.Building.HandsLogic
{
    public class HandsItemView : MonoBehaviour
    {
        [SerializeField] private ItemType type;

        public ItemType Type => type;
    }
}