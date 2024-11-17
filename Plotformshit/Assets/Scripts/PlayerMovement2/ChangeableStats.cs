using UnityEngine;

namespace PlayerController
{
    [CreateAssetMenu]
    public class ChangeableStats : MonoBehaviour
    {
        [Header("LAYERS")]
        [Tooltip("The layer the player is on")]
        public LayerMask PlayerLayer;

        [Header("MOVEMENT")]
        [Tooltip("The pace that the player will stop moving")]
        public float GroundDeceleration = 60;

        [Tooltip("Deceleration iin the air when stopping input mid-air")]
        public float AirDeceleration = 30;

        [Tooltip("The maximum speed that the player can achieve")]
        public float Speed = 14;

        [Tooltip("How fast the player reaches maximum speed")]
        public float Acceleration = 120;

        [Header("JUMP")]
        [Tooltip("Empty Tooltip")]
        public float JumpPower = 36;
        [Tooltip("The ammount of time to buffer a jump. Allows for a jump input before hitting the ground")]
        public float JumpBufferTime = .2f;

        public float CoyoteTime = .3f;

        [Header("Gravity")]

        [Tooltip("The force applied when on the ground"), Range(0f, -10f)]
        public float GroundForce = -1.5f;

        [Tooltip("Gravity multiplier applied when ending jump early")]
        public float EarlyJumpEndGravityModifier = 3;

        [Tooltip("The maximum speed the player can fall")]
        public float MaxFallSpeed = 40;

        [Tooltip("Gravity when falling")]
        public float FallAcceleration = 110;


    }
}
