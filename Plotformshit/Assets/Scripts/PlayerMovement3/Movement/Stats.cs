using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    [CreateAssetMenu]
    public class Stats : MonoBehaviour
    {
        [Tooltip("The detection distance for grounding and roof detection"), Range(0f, 0.5f)]
        public float DetectionDistance;

        [Header("LAYERS")]
        [Tooltip("Set this to the layer your player is on")]
        public LayerMask PlayerLayer;

        public float Speed = 3.5f;

        [Tooltip("The ammount of time to buffer a jump. Allows for a jump input before hitting the ground")]
        public float JumpBufferTime = 0.01f;

        public float CoyoteTime = 0.2f;

        public float JumpPower = 30f;

        public float OnGroundDeceleration = 60f;

        public float InAirDeceleration = 30f;

        public float Acceleration = 120f;

        public float AccelerationWhileFalling = 60f;

        public float GroundGravity = -1.5f;

        public float JumpEndEarlyModifier = 3f;

        public float TerminalVelocity = 40f;

        public float HangInAirMultiplier = 0.2f;

        public float HangInAirThreshold = 0.5f;
    }
}
