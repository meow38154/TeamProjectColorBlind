using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.SO.Player;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class Player : MonoBehaviour
    {
    
        [Header("Component")]
        public AgentMovement MovementCompo { get; private set; }
        public AgentRenderer RendererCompo { get; private set; }
        [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }
    
        private bool _canDoubleJump;

        private void Awake()
        {
            MovementCompo = GetComponentInChildren<AgentMovement>();
            RendererCompo = GetComponentInChildren<AgentRenderer>();
            PlayerInput.OnJumpKeyPressed += HandleJumpPressed;
        }

        private void OnDestroy()
        {
            PlayerInput.OnJumpKeyPressed -= HandleJumpPressed;
        }

        private void FixedUpdate()
        {
            SetUpMovementInput();
        }
        private void Update()
        {
            Debug.Log(PlayerInput.MousePos);
            SetUpMovementInput();
            RendererCompo.FaceDirection(PlayerInput.MousePos.normalized);
        }

        private void HandleJumpPressed()
        {
            if (!MovementCompo.isGrounded && !_canDoubleJump) return;
            if (MovementCompo.isGrounded) // 처음 점프
            {
                _canDoubleJump = true;
            }
            else if (_canDoubleJump) // 점프 후 더블 점프 가능
            {
                _canDoubleJump = false;
            }
            MovementCompo.Jump();
        }
        private void SetUpMovementInput()
        {
            MovementCompo.SetMove(PlayerInput.MoveDir.x); // 플레이어 인풋으로 받아온 MoveDir(Vector)의 x값을 AgentMovement의 XMove의 값에 저장한다.
        }
    
    }
}
