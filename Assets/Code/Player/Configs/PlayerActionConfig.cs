using Code.Player.Data;
using UnityEngine;

namespace Code.Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerActionConfig", menuName = "ScriptableObjects/Player/PlayerActionConfig", order = 1)]
    public class PlayerActionConfig : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float distanceToGround = 0.1f;
        [SerializeField] private float jumpForce = 4f;
        [SerializeField] private float gravity = 9.81f;

        //Move to saves if you need a change from the user.
        [Header("CameraSettings")]
        [SerializeField] private float cameraSensitivity = 1f;
        [SerializeField] private float maxVerticalAngel = 70f;
        [SerializeField] private float minVerticalAngel = -70f;

        [Header("InteractionSettings")]
        [SerializeField] private float interactDistance = 5f;
        
        [Header("BuildingSettings")]
        [SerializeField] private float maxBuildDistance = 5f;

        #region Movement

        public float MoveSpeed => moveSpeed;

        public LayerMask GroundMask => groundMask;

        public float DistanceToGround => distanceToGround;

        public float JumpForce => jumpForce;

        public float Gravity => gravity;

        #endregion

        #region CameraSettings

        public float CameraSensitivity => cameraSensitivity;

        public float MaxVerticalAngel => maxVerticalAngel;

        public float MinVerticalAngel => minVerticalAngel;

        #endregion

        #region InteractionSettings

        public float InteractDistance => interactDistance;

        #endregion
        
        #region BuildingSettings

        public float MaxBuildDistance => maxBuildDistance;

        #endregion
    }
}