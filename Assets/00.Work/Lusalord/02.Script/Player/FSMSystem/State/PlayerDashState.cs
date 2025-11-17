namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override PlayerStates States { get; }
    }
}