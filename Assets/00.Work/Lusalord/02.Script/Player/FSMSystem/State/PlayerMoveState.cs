
using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerMoveState : PlayerState
    {
        private AnimatorParameterSO _moveParameter;
        public override PlayerStates States => PlayerStates.Move;
        
        public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
            
        }

        public override void Enter()
        {
            _moveParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Move);
            if(_moveParameter != null)
                Player.RendererCompo.SetParameter(_moveParameter, true);
        }

        public override void Update()
        {
            bool isIdle = Mathf.Approximately(Player.PlayerInput.MoveDir.x, 0);
            if (isIdle)
            {
                StateMachine.ChangeState(PlayerStates.Idle);
                return;
            }
            
            bool canJump = Player.PlayerInput.jumpPressedFlag && Player.MovementCompo.IsGrounded;
            if (canJump)
            {
                Player.ConsumeJumpFlag();
                StateMachine.ChangeState(PlayerStates.Jump);
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
            Player.RendererCompo.SetParameter(_moveParameter, false);
        }
    }
}