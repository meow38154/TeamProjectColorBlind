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
        public HealthSystem HealthSystem { get; private set; }
        public DamageCaster DamageCaster { get; private set; }

        [field: SerializeField] public PlayerInputSo PlayerInput { get; private set; }

        private PlayerStateMachine _playerStateMachine;

        public bool CanDoubleJump { get; private set; }
        public bool jumpCount;
        private float _timeInAir;
        public UnityEvent onJumpPressEvent;

        [SerializeField] private float dashSpeed = 20f;
        [SerializeField] private int dashCount = 1;

        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 1f;

        public bool isDamaged;
        private bool _canDash = true;
        private bool _isDashing;
        private float _dashTimeLeft;
        private float _dashCooldownTimeLeft;

        [SerializeField] private float _attackCoolTime = 0.2f;

        private void Awake()
        {
            MovementCompo = GetComponentInChildren<AgentMovement>();
            RendererCompo = GetComponentInChildren<AgentRenderer>();
            HealthSystem = GetComponentInChildren<HealthSystem>();
            DamageCaster = GetComponentInChildren<DamageCaster>();

            PlayerInput.OnJumpKeyPressed += HandleJumpPressed;
            PlayerInput.OnDashKeyPressed += HandleDashPressed;
            HealthSystem.OnGetDamage += HandleHitState;
            HealthSystem.OnDie += HandleDeathState;
            PlayerInput.OnAttackKeyPressed += HandleAttackState;

            _playerStateMachine = new PlayerStateMachine(this);
        }

        private void OnDestroy()
        {
            PlayerInput.OnJumpKeyPressed -= HandleJumpPressed;
            PlayerInput.OnDashKeyPressed -= HandleDashPressed;
            HealthSystem.OnGetDamage -= HandleHitState;
            HealthSystem.OnDie -= HandleDeathState;
            PlayerInput.OnAttackKeyPressed -= HandleAttackState;
        }

        private void Start()
        {
            _playerStateMachine.Initialize(PlayerStates.Idle);
        }

        private void FixedUpdate()
        {
            if (MovementCompo.IsGrounded)
            {
                CanDoubleJump = true;
                dashCount = 1;
            }

            RendererCompo.FaceDirection(PlayerInput.MoveDir);
        }

        private void Update()
        {
            if (!_canDash)
            {
                _dashCooldownTimeLeft -= Time.deltaTime;
                if (_dashCooldownTimeLeft <= 0)
                    _canDash = true;
            }

            SetUpMovementInput();
            _playerStateMachine.UpdateMachine();
        }

        private void HandleJumpPressed()
        {
            if (!MovementCompo.IsGrounded && !CanDoubleJump) return;

            if (MovementCompo.IsGrounded)
            {
                SoundManager.Instance.PlaySound(4, 0.2f);
                CanDoubleJump = true;
            }
            else if (CanDoubleJump)
            {

                CanDoubleJump = false;
            }
            onJumpPressEvent?.Invoke();
            MovementCompo.Jump();
            _timeInAir = 0;
        }

        private void HandleDashPressed()
        {
            if (!MovementCompo.IsGrounded)
            {
                if (dashCount <= 0) return;
                dashCount--;
            }

            MovementCompo.Dash(new Vector2(RendererCompo.DirRotation, 0));
        }

        private void SetUpMovementInput()
        {
            if (_isDashing)
                return;
            MovementCompo.SetMove(PlayerInput.MoveDir.x);
        }

        private IEnumerator DashRoutine()
        {
            while (_dashTimeLeft > 0)
            {
                _dashTimeLeft -= Time.deltaTime;
                yield return null;
            }
            _isDashing = false;
        }

        public void ConsumeJumpFlag()
        {
            PlayerInput.jumpPressedFlag = false;
        }

        private bool _attack = true;

        private void HandleAttackState()
        {
            if (_attack)
            {
                StartCoroutine(AttackCoolTime());
                if (_playerStateMachine.CurrentState.States == PlayerStates.Hit) return;
                if (_playerStateMachine.CurrentState.States == PlayerStates.Death) return;

                SoundManager.Instance.PlaySound(1, 0.4f);
                _playerStateMachine.ChangeState(PlayerStates.Attack);
            }
        }

        private IEnumerator AttackCoolTime()
        {
            _attack = false;
            yield return new WaitForSeconds(_attackCoolTime);
            _attack = true;
        }

        private void HandleHitState(int a, Transform t)
        {
            _playerStateMachine.ChangeState(PlayerStates.Hit);
        }

        private void HandleDeathState()
        {
            _playerStateMachine.ChangeState(PlayerStates.Death);
        }
    }
}
