using _00.Work.Lusalord._02.Script.SO;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerDoubleJumpState : PlayerState
    {
        private AnimatorParameterSO _doubleJumpParameter;
        public override PlayerStates States => PlayerStates.DoubleJump;
        
        public PlayerDoubleJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }
        
        public override void Enter()
        {
            _doubleJumpParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.DoubleJump);
            Player.RendererCompo.SetParameter(_doubleJumpParameter, true);
        }
        public override void Update()
        {
            bool isFall = Player.MovementCompo.Rb.linearVelocityY < 0;
            if (isFall)
            {
                StateMachine.ChangeState(PlayerStates.Fall);
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
            Player.RendererCompo.SetParameter(_doubleJumpParameter, false);
        }
    }
}