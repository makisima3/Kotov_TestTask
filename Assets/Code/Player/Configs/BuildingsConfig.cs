using System;
using System.Collections.Generic;
using System.Linq;
using Code.Building;
using Code.Building.Enums;
using Code.Player.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Player.Configs
{
    [Serializable]
    public class BuildingData
    {
        public ItemType Type;
        public GameObject GhostObject;
        public PlacedItem PlacedObject;
        public LayerMask ValidBuildLayers;
        public LayerMask ValidContactLayers;
        public bool LootLikeNormal;
    }

    [CreateAssetMenu(fileName = "BuildingsConfig", menuName = "ScriptableObjects/Player/BuildingsConfig", order = 1)]
    public class BuildingsConfig : ScriptableObject
    {
        [SerializeField] private List<BuildingData> BuildingData;

        public BuildingData GetBuildingData(ItemType type)
        {
            return BuildingData.First(b => b.Type == type);
        }
    }
}