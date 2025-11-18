using System.Collections;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerJumpState : PlayerState
    {
        private AnimatorParameterSO _jumpParameter;

        public override PlayerStates States => PlayerStates.Jump;
        public PlayerJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
            
        }
    
        public override void Enter()
        {
            _jumpParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Jump);
            Player.RendererCompo.SetParameter(_jumpParameter, true);
        }

        public override void Update()
        {
            if (!Player.MovementCompo.IsGrounded && !Player.CanDoubleJump && Player.PlayerInput.jumpPressedFlag)
            {
                Player.ConsumeJumpFlag();
                StateMachine.ChangeState(PlayerStates.DoubleJump);
                return;
            }

            if (Player.MovementCompo.Rb.linearVelocity.y < 0)
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
            Player.RendererCompo.SetParameter(_jumpParameter, false);
        }
    }
}