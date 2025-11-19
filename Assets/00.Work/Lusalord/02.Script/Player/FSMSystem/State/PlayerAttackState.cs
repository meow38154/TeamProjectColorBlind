using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;
namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerAttackState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Attack;
        private AnimatorParameterSO _attackParameter;
        
        public PlayerAttackState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
        {
            
        }

        public override void Enter()
        {
            _attackParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Attack);
            Player.RendererCompo.SetParameter(_attackParameter);
        }
        
        public override void Update()
        {
            AnimatorStateInfo info = Player.RendererCompo.animator.GetCurrentAnimatorStateInfo(0);
            
            if (info.normalizedTime > 1f)
            {
                StateMachine.ChangeState(PlayerStates.Idle);
            }
        }

        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_attackParameter, false);
        }
        public void AttackEvent_EnableHitBox()
        {
            Player.DamageCaster.attackHandler.EnableHitBox();
        }

        public void AttackEvent_DisableHitBox()
        {
            Player.DamageCaster.attackHandler.DisableHitBox();
        }
    }
}