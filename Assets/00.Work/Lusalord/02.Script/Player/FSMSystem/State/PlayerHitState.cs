using _00.Work.Lusalord._02.Script.SO;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerHitState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Hit;
        private AnimatorParameterSO _hitParameter;
        public PlayerHitState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
            _hitParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Hit);
            Player.RendererCompo.SetParameter(_hitParameter, true);
            Player.PlayerInput.LockInput(true);
        }
        public override void Update()
        {
            if (Player.RendererCompo.IsAnimationFinished(_hitParameter.ParameterName))
            {
                StateMachine.ChangeState(PlayerStates.Idle);
            }
        }
        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_hitParameter, false);
            Player.PlayerInput.LockInput(false);
        }

    }
}