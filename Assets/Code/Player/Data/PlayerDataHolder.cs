using Code.Player.Configs;
using Code.Player.Data.StorageObjects;
using UnityEngine;
using Zenject;

namespace Code.Player.Data
{
    public class PlayerDataHolder : MonoBehaviour
    {
        [SerializeField] private PlayerDataConfig playerDataConfig;

        private PlayerStorageObject _playerStorageObject;

        public PlayerData PlayerData => _playerStorageObject.Data;

        public void Awake()
        {
            _playerStorageObject = new PlayerStorageObject(playerDataConfig.PlayerData).Load();
        }

        private void OnApplicationQuit()
        {
            Save();
            PlayerPrefs.Save();
        }


        [ContextMenu("Save")]
        public void Save()
        {
            _playerStorageObject.Save();
        }
    }
}