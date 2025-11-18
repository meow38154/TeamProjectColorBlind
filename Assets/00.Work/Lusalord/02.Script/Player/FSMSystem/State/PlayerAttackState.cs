using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;
namespace _00.Work.Lusalord._02.Script.Player.FSMSystem.State
{
    public class PlayerAttackState : PlayerState
    {
        public override PlayerStates States => PlayerStates.Attack;
        private AnimatorParameterSO _attackParameter;

        private bool _turnedOn;
        
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
            if (_turnedOn)
            {
                Player.RendererCompo.SetParameter(_attackParameter, false);
                _turnedOn = false;
            }
            
        }

        public override void Exit()
        {
            Player.RendererCompo.SetParameter(_attackParameter, false);
        }
    }
}