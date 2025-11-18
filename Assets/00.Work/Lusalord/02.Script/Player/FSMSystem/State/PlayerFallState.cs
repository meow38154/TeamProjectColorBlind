using _00.Work.Lusalord._02.Script.SO;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem
{
    public class PlayerFallState : PlayerState
    {
        private AnimatorParameterSO _fallParameter;
        public override PlayerStates States => PlayerStates.Fall;
        
        public PlayerFallState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            _fallParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Fall);
            Player.RendererCompo.SetParameter(_fallParameter, true);
        }
        public override void Update()
        {
            bool isIdle = Player.MovementCompo.IsGrounded;
            if (isIdle)
            {
                StateMachine.ChangeState(PlayerStates.Idle);
                return;
            }

            bool isDoubleJump = !Player.MovementCompo.IsGrounded && !Player.CanDoubleJump &&
                                 Player.PlayerInput.jumpPressedFlag;
            if (isDoubleJump)
            {
                Player.ConsumeJumpFlag();
                StateMachine.ChangeState(PlayerStates.DoubleJump);
                return;
            }
            if (Player.MovementCompo.isDash)
            {
                StateMachine.ChangeState(PlayerStates.Dash);
                return;
            }
        }
        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_fallParameter, false);
        }
    }
}