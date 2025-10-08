    using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.SO.Player;
using UnityEngine;
using UnityEngine.Events;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class Player : MonoBehaviour
    {   
        #region Component
            [Header("Component")]
        
            public AgentMovement MovementCompo { get; private set; }
            public AgentRenderer RendererCompo { get; private set; }
        #endregion

        #region AddGravity
            [Header("AddGravity")]
            
            [SerializeField] private float extraGravity;
            [SerializeField] private float gravityDelay;
            
            private float _timeInAir = 0;
        #endregion

        [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }
        
        private bool _canDoubleJump;

        

        public UnityEvent onJumpPressEvent;

        private void Awake()
        {
            MovementCompo = GetComponentInChildren<AgentMovement>();
            RendererCompo = GetComponentInChildren<AgentRenderer>();
            PlayerInput.OnJumpKeyPressed += HandleJumpPressed;
            PlayerInput.OnDashKeyPressed += HandleDashPressed;
        }

        private void OnDestroy()
        {
            PlayerInput.OnJumpKeyPressed -= HandleJumpPressed; // 플레이어가 삭제되면 점프가 필요 없기 때문에 점프를 뺀다.
            PlayerInput.OnDashKeyPressed -= HandleDashPressed;
        }

        private void FixedUpdate()
        {
            Debug.Log(PlayerInput.MousePos);
            ApplyExtraGravity();
        }
        
        private void Update()
        {
            SetUpMovementInput();
            InAirTime();
            RendererCompo.FaceDirection(PlayerInput.MousePos);
        }

        private void HandleJumpPressed() // 점프를 담당하는 메서드
        {
            // if(!MovementCompo.IsGrounded && !_canDoubleJump) return;
            
            if (MovementCompo.IsGrounded) // 처음 점프
            {
                onJumpPressEvent?.Invoke();     
                MovementCompo.Jump(); // 점프 키가 눌렸을 때 점프 명령을 내린다.
                // _canDoubleJump = true;
            }
            // else if (_canDoubleJump) // 점프 후 더블 점프 가능
            // {
            //     _canDoubleJump = false;
            // }
            
            _timeInAir = 0;
        }

        private void HandleDashPressed()
        {
            Vector2 dir = PlayerInput.MousePos - (Vector2)transform.position;
            MovementCompo.Dash(dir.normalized);
        }
        private void SetUpMovementInput()
        {
            MovementCompo.SetMove(PlayerInput.MoveDir.x); // 플레이어 인풋으로 받아온 MoveDir(Vector)의 x값을 AgentMovement의 XMove의 값에 지속적으로 전달한다.
        }
        
        private void ApplyExtraGravity() // 공중에 떠있는 시간이 gravityDelay보다 커지면 플레이어를 떨어뜨린다.
        {
            if (_timeInAir > gravityDelay)
            {
                MovementCompo.AddGravityForce(new Vector2(0, -extraGravity));
            }
        }
        
        private void InAirTime() // 공중에 떠있는 시간을 구하는 메서드
        {
            if (MovementCompo.IsGrounded == false)
            {
                _timeInAir += Time.deltaTime;
            }
            else
            {
                _timeInAir = 0;
            }
        }
    }
}
