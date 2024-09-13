﻿using System;
using PersistentStorage;
using UnityEngine;

namespace Code.Player.Data.StorageObjects
{
    public class PlayerStorageObject : PlainStorageObject<PlayerStorageObject, PlayerData>
    {
        public override string PrefKey => nameof(PlayerStorageObject);

        public PlayerStorageObject(PlayerData defaultData, Action<PlayerData> afterLoading = null, Func<PlayerData> beforeSaving = null) : base(defaultData, afterLoading, beforeSaving)
        {
        }
    }
}