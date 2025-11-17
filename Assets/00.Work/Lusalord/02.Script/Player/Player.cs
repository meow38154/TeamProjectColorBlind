using System;
using System.Collections;
using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.Player.FSMSystem;
using _00.Work.Lusalord._02.Script.SO.Player;
using UnityEngine;
using UnityEngine.Events;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class Player : MonoBehaviour
    {   
        public AgentMovement MovementCompo { get; private set; }
        public AgentRenderer RendererCompo { get; private set; }
        private Animator Animator => RendererCompo.animator;
        [field: SerializeField] public PlayerInputSo PlayerInput { get; private set; }
        
        private PlayerStateMachine _playerStateMachine;

        public bool CanDoubleJump { get; private set; }
        public bool jumpCount;
        private float _timeInAir;
        public UnityEvent onJumpPressEvent;

        private void Awake()
        {
            MovementCompo = GetComponentInChildren<AgentMovement>();
            RendererCompo = GetComponentInChildren<AgentRenderer>();
            
            PlayerInput.OnJumpKeyPressed += HandleJumpPressed;
            
            _playerStateMachine = new PlayerStateMachine(this);
        }
        
        private void OnDestroy()
        {
            PlayerInput.OnJumpKeyPressed -= HandleJumpPressed;
        }

        private void Start()
        {
            _playerStateMachine.Initialize(PlayerStates.Idle);
        }

        private void FixedUpdate()
        {
            if (MovementCompo.IsGrounded)
                CanDoubleJump = true;
        }

        private void Update()
        {
            SetUpMovementInput();
            _playerStateMachine.UpdateMachine();
        }
        
        private void HandleJumpPressed() // 점프를 담당하는 메서드
        {
            if(!MovementCompo.IsGrounded && !CanDoubleJump) return;
            
            if (MovementCompo.IsGrounded) // 처음 점프
            {
                CanDoubleJump = true;
            }
            else if (CanDoubleJump) // 점프 후 더블 점프 가능
            {
                CanDoubleJump = false;
            }
            onJumpPressEvent?.Invoke();     
            MovementCompo.Jump(); // 점프 키가 눌렸을 때 점프 명령을 내린다.
            _timeInAir = 0;
        }
        private void SetUpMovementInput()
        {
            MovementCompo.SetMove(PlayerInput.MoveDir.x); // 플레이어 인풋으로 받아온 MoveDir(Vector)의 x값을 AgentMovement의 XMove의 값에 지속적으로 전달한다.
        }
        public void ConsumeJumpFlag()
        {
            PlayerInput.jumpPressedFlag = false;
        }
    }
}
