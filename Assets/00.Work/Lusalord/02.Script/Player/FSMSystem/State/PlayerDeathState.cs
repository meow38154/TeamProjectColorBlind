namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerDeathState : PlayerState
    {
        public PlayerDeathState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }

        public override PlayerStates States { get; }
    }
}