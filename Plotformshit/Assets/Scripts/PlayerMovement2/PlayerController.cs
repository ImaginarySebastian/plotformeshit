using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerController
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayer;
        [SerializeField] private ChangeableStats _stats;
        private Rigidbody2D _rb;
        private BoxCollider2D _col;
        private Vector2 _movementVelocity;
        private float horizontalMovement;
        private float distToGround;
        private bool pressedJump;
        private float horizontal;

        private bool _cahcedQueryStartInColliders;
        public event Action<bool, float> GroundedChange;
        public event Action Jumped;

        private float _time;

        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<BoxCollider2D>();
            _cahcedQueryStartInColliders = Physics2D.queriesStartInColliders;
            distToGround = _col.bounds.extents.y;
        }

        private void Update() 
        {
            _time += Time.deltaTime;

        }

        #region Inputs

        public void JumpInput(InputAction.CallbackContext context) 
        {
            _whenWasJumpPressed = _time;
            if (context.performed) pressedJump = true;
            else if (context.canceled) pressedJump = false;
            _jumpToUse = true;
            Jump();
        }

        public void horizontalInput(InputAction.CallbackContext context)
        {
            horizontal = context.ReadValue<Vector2>().x;
        }

        #endregion

        private void FixedUpdate()
        {
            Gravity();
            ApplyMovement();
        }


        #region Ground Check

        private float _frameLeftGrounded = float.MinValue;

        bool IsGrounded()
        {
            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;
            float distance = 1f;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
            if (hit.collider != null)
            {
                Debug.Log("OnGround" + transform.position.x);

                _bufferedJumpIsUsable = true;
                _coyoteUsable = true;
                _endedJumpEarly = false;

                return true;

            }
            else
            {
                _frameLeftGrounded = _time;
                return false;
            }
        }

        #endregion

        #region Vertical

        private bool _jumpToUse;
        private bool _bufferedJumpIsUsable;
        private bool _endedJumpEarly;
        private bool _coyoteUsable;
        private float _whenWasJumpPressed;

        private bool HasBufferedJump => _bufferedJumpIsUsable && _time < _whenWasJumpPressed + _stats.JumpBufferTime;
        private bool CanUseCoyote => _coyoteUsable && !IsGrounded() && _time < _frameLeftGrounded + _stats.CoyoteTime;

        private void Jump()
        {

            Debug.Log(CanUseCoyote);
            _whenWasJumpPressed = _time;

            if (!_endedJumpEarly && !IsGrounded() && !pressedJump && _rb.velocity.y > 0)
            {
                _endedJumpEarly = true;
            }
            if (!_jumpToUse && !HasBufferedJump)
            {
                return;
            }
            if (pressedJump && IsGrounded() || pressedJump && CanUseCoyote) 
            {
                ExecuteJump();
            }

            _jumpToUse = false;
        }

        private void ExecuteJump()
        {
            _endedJumpEarly = false;
            _whenWasJumpPressed = 0;
            _bufferedJumpIsUsable = false;
            _coyoteUsable = false;
            _movementVelocity.y = _stats.JumpPower;
            Jumped?.Invoke();


        }

        #endregion


        #region Gravity

        private void Gravity()
        {
            if (IsGrounded() && _movementVelocity.y <= 0f)
            {
                _movementVelocity.y = _stats.GroundForce;
            }
            else
            {
                var inAirGravity = _stats.FallAcceleration;
                if (_endedJumpEarly && _movementVelocity.y > 0)
                {
                    inAirGravity *= _stats.EarlyJumpEndGravityModifier;
                    
                }
                _movementVelocity.y = Mathf.MoveTowards(_movementVelocity.y, -_stats.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
            }
        }

        #endregion

        private void ApplyMovement() 
        {
            _rb.velocity = new Vector2(horizontal * _stats.Speed, _movementVelocity.y);
        }

    }
}
