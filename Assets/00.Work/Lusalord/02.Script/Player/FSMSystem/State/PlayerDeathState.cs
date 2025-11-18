using _00.Work.Lusalord._02.Script.SO;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerDeathState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Death;
        private AnimatorParameterSO _deathParameter;
        public PlayerDeathState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override void Enter()
        {
            _deathParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Death);
            Player.RendererCompo.SetParameter(_deathParameter, true);
            Player.PlayerInput.LockInput(true);
            
        }
        public override void Update()
        {
            
        }
        public override void Exit()
        {
            
        }
    }
}