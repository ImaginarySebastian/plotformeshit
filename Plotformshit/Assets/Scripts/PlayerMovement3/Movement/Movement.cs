using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] Stats _stats;
        [SerializeField] private CapsuleCollider2D collider;
        [SerializeField] private Rigidbody2D rigidbody;
        private Vector2 _movementVelocity;
        private bool grounded;
        private float timeLeftGround;
        private float horizontal;
        private bool jumpEndedEarly;
        private bool pressedJump;
        private bool isAtPeakJump;

        private bool isFacingRight = true;

        void Start()
        {

        }

        void Update()
        {

            if((!isFacingRight &&  horizontal > 0f) || isFacingRight && horizontal < 0f) Flip();


        }

        #region Input



        public void JumpInput(InputAction.CallbackContext context) 
        {
            
            if (context.performed)
            {
                pressedJump = true;
            }
            else if (context.canceled) 
            {
                pressedJump = false;
            }
            jumpToUse = true;
            timeAtJump = Time.time;

        }

        public void horizontalInput(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }

        #endregion


        private void FixedUpdate()
        {
            CollisionCheck();

            CheckJump();
            HandleDirection();
            Gravity();
            Move();
        }





        #region Collision Check

        private void CollisionCheck() 
        {
            Physics2D.queriesStartInColliders = false;

            // Ground and Ceiling
            bool groundHit = Physics2D.CapsuleCast(collider.bounds.center, collider.size, collider.direction, 0, Vector2.down, _stats.DetectionDistance, ~_stats.PlayerLayer);
            bool ceilingHit = Physics2D.CapsuleCast(collider.bounds.center, collider.size, collider.direction, 0, Vector2.up, _stats.DetectionDistance, ~_stats.PlayerLayer);

            // Hit a Ceiling
            if (ceilingHit) _movementVelocity.y = Mathf.Min(0, _movementVelocity.y);

            // Landed on the Ground
            if (!grounded && groundHit)
            {
                grounded = true;
                coyoteAllowed = true;
                canUseBufferedJump = true;
                jumpEndedEarly = false;
            }
            // Left the Ground
            else if (grounded && !groundHit)
            {
                timeLeftGround = Time.time;
                Debug.Log(timeLeftGround);
                grounded = false;
              //  _frameLeftGrounded = _time;
            }

        }

        #endregion

        #region Movement

        private void HandleDirection() 
        {
            if (horizontal == 0) 
            {
                var deceleration = grounded ? _stats.OnGroundDeceleration : _stats.InAirDeceleration;
                _movementVelocity.x = Mathf.MoveTowards(_movementVelocity.x, 0, deceleration * Time.fixedDeltaTime);
            }
            else 
            {
                _movementVelocity.x = Mathf.MoveTowards(_movementVelocity.x, horizontal * _stats.Speed, _stats.Acceleration * Time.fixedDeltaTime);
            }
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        #endregion

        #region Jump

        private bool jumpToUse;
        private bool canUseBufferedJump;
        private bool endedJumpEarly;
        private bool coyoteAllowed;
        private float timeAtJump;

        private bool HasBufferedJump => canUseBufferedJump && Time.time < timeAtJump + _stats.JumpBufferTime;
        private bool CanUseCoyote => coyoteAllowed && !grounded && Time.time < timeLeftGround + _stats.CoyoteTime;

        private void CheckJump() 
        {
            

            if(!jumpEndedEarly && !grounded && !pressedJump && rigidbody.velocity.y > 0) 
            {
                jumpEndedEarly = true;
            }
            if (!jumpToUse) 
            {
                return;
            }

            if (pressedJump && grounded || pressedJump && CanUseCoyote || HasBufferedJump && (grounded || CanUseCoyote))
            {
                Jump();
            }
        }

        private void Jump() 
        {
            jumpEndedEarly = false;
            timeAtJump = 0;
           // canUseBufferedJump = false;
            coyoteAllowed = false;
            _movementVelocity.y = _stats.JumpPower;
        }

        #endregion

        #region Gravity

        private void Gravity()
        {
            
            if (grounded && _movementVelocity.y <= 0f)
            {
                _movementVelocity.y = _stats.GroundGravity;
            }

            else
            {
                var inAirGravity = _stats.AccelerationWhileFalling;
                if (!grounded && Mathf.Abs(rigidbody.velocity.y) < _stats.HangInAirThreshold)
                {
                    inAirGravity = inAirGravity * _stats.HangInAirMultiplier;
                }
                else if (jumpEndedEarly && _movementVelocity.y > 0)
                {
                    inAirGravity *= _stats.JumpEndEarlyModifier;
                }
                _movementVelocity.y = Mathf.MoveTowards(_movementVelocity.y, -_stats.TerminalVelocity, inAirGravity * Time.fixedDeltaTime);
            }
        }

        #endregion
        private void Move()
        {
            rigidbody.velocity = new Vector2(_movementVelocity.x * _stats.Speed, _movementVelocity.y);
        }
    }
}
