using _00.Work.Lusalord._02.Script.SO;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerDashState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Dash;
        private AnimatorParameterSO _dashParameter;
        public PlayerDashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
            _dashParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Dash);
            Player.RendererCompo.SetParameter(_dashParameter, true);
        }
        
        public override void Update()
        {
            if (!Player.MovementCompo.isDash)
            {
                StateMachine.ChangeState(PlayerStates.Idle);
            }
        }
        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_dashParameter, false);
        }

    }
}