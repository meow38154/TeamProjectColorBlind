using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.Lusalord._02.Script.SO.Player
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/Player/PlayerInputSO")]
    public class PlayerInputSo : ScriptableObject, InputSystem_Actions.IPlayerActions
    {
        private InputSystem_Actions _input;
        public Action OnJumpKeyPressed;
        public bool jumpPressedFlag;
        public Action OnDashKeyPressed;
        public Action OnAttackKeyPressed { get; set; }

        public Vector2 MoveDir { get; set; }
        public Vector2 MousePos { get; private set; }
        public bool OnLock { get; private set; } = false;
        
        public void LockInput(bool isLock)
        {
            
            OnLock = isLock;
        }
        private void OnEnable()
        {
            if (_input == null)
            {
                _input = new InputSystem_Actions();
                _input.Player.SetCallbacks(this);
            }
            _input.Player.Enable();
        }

        private void OnDisable()
        {
            _input.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if (OnLock) return;
            Debug.Log(MoveDir + " ¿Ö??");
            MoveDir = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (OnLock) return;
            if (context.performed)
            {
                jumpPressedFlag = true;
                OnJumpKeyPressed?.Invoke();
            }   
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (OnLock) return;
            if (UnityEngine.Camera.main)
            {
                MousePos = UnityEngine.Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            }
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (OnLock) return;
            if (context.performed)
            {
                OnDashKeyPressed?.Invoke();
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnAttackKeyPressed?.Invoke();
            }
        }
    }
}
