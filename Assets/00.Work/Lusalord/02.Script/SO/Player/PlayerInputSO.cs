using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.Lusalord._02.Script.SO.Player
{
    [CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/Player/PlayerInputSO")]
    public class PlayerInputSO : ScriptableObject, InputSystem_Actions.IPlayerActions
    {
        private InputSystem_Actions _input;
        public Action OnJumpKeyPressed;

        public Vector2 MoveDir { get; private set; }
        public Vector2 MousePos { get; private set; }
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
            MoveDir = context.ReadValue<Vector2>();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnJumpKeyPressed.Invoke();
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            if (Camera.main)
            {
                MousePos = Camera.main.world(context.ReadValue<Vector2>());
            }
        }
    }
}
