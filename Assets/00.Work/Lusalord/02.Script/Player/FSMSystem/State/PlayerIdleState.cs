using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerIdleState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Idle;
        private AnimatorParameterSO _idleParameter;
        
        public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
            
        }

        public override void Enter()
        {
            _idleParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Idle);
            Player.RendererCompo.SetParameter(_idleParameter, true);
        }

        public override void Update()
        {
            bool isMove = Mathf.Abs(Player.PlayerInput.MoveDir.x) > 0;
            if (isMove)
            {
                StateMachine.ChangeState(PlayerStates.Move);
                return;
            }

            bool canJump = Player.PlayerInput.jumpPressedFlag && Player.MovementCompo.IsGrounded;
            if (canJump)
            {
                Player.ConsumeJumpFlag();
                StateMachine.ChangeState(PlayerStates.Jump);
                return;
            }
        }

        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_idleParameter, false);
        }
    }
}