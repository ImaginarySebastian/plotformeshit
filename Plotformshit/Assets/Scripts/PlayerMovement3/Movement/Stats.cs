using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    [CreateAssetMenu]
    internal class Stats : MonoBehaviour
    {
        [Tooltip("The detection distance for grounding and roof detection")]
        [SerializeField] internal float DetectionDistanceY = 0.05f;
        [Tooltip("The detection distance for walls")]
        [SerializeField] internal float GrabbingDistance = 1f;
        [Tooltip("How far away should be counted as on the wall")]
        [SerializeField] internal float TouchingWallDistance = 0.05f;

        [Header("LAYERS")]
        [Tooltip("Set this to the layer your player is on")]
        [SerializeField] internal LayerMask PlayerLayer;

        [SerializeField] internal float Speed = 3.5f;

        [Tooltip("The ammount of time to buffer a jump. Allows for a jump input before hitting the ground")]
        [SerializeField] internal float JumpBufferTime = 0.01f;

        [SerializeField] internal float CoyoteTime = 0.2f;

        [SerializeField] internal float JumpPower = 30f;

        [SerializeField] internal float OnGroundDeceleration = 60f;

        [SerializeField] internal float InAirDeceleration = 30f;

        [SerializeField] internal float Acceleration = 120f;

        [SerializeField] internal float AccelerationWhileFalling = 60f;

        [SerializeField] internal float GroundGravity = -1.5f;

        [SerializeField] internal float JumpEndEarlyModifier = 3f;

        [SerializeField] internal float TerminalVelocity = 40f;

        [SerializeField] internal float HangInAirMultiplier = 0.2f;

        [SerializeField] internal float HangInAirThreshold = 0.5f;

        [SerializeField] internal float MaxDoubleJumps = 3;
        [SerializeField] internal float DoubleJumpThreshold = 0.5f;

        [SerializeField] internal float GlideFallSpeed = 10;

        [SerializeField] internal float GlideMoveSpeedModifier = 0.25f;

        [SerializeField] internal float DashTime = 0.25f;
    }
}
