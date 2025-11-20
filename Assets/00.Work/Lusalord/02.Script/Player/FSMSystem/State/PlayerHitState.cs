using System.Collections;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerHitState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Hit;
        private AnimatorParameterSO _hitParameter;
        
        private bool _animationFinished;
        public PlayerHitState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
        }
        public override void Enter()
        {
            _hitParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Hit);
            Player.RendererCompo.SetParameter(_hitParameter);
            //Player.PlayerInput.LockInput(true);
        }
        public override void Update()
        {
            AnimatorStateInfo info = Player.RendererCompo.animator.GetCurrentAnimatorStateInfo(0);
            if (info.normalizedTime >= 0.4f)
            {
                Player.PlayerInput.LockInput(false);
                StateMachine.ChangeState(PlayerStates.Idle);
            }
        }
        public override void Exit()
        {
            
        }
    }
}