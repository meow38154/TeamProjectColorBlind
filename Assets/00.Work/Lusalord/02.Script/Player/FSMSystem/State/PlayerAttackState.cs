using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;
using System.Collections;
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
            Debug.Log("АјАн");
            _attackParameter = AnimatorParamManage.Instance.GetParameter(PlayerStates.Attack);
            Player.RendererCompo.SetParameter(_attackParameter);

            Player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            GameObject attack = Player.transform.Find("VisualAttack").gameObject;
            attack.SetActive(true);
            Animator attackAnim = attack.GetComponent<Animator>();

            attack.transform.localScale = new Vector3(attack.transform.rotation.y != 0 ? -1 : 1, 1, 1);

            float x = (Player.DamageCaster.transform.position.x - Player.transform.position.x);
            float y = Player.DamageCaster.transform.position.y - Player.transform.position.y;

            attackAnim.SetFloat("x", x);
            attackAnim.SetFloat("y", y);
            Player.StartCoroutine(AttackTime());
            Player.StartCoroutine(AttackBox());
        }

        private IEnumerator AttackTime()
        {
            yield return new WaitForSeconds(0.2f);
            StateMachine.ChangeState(PlayerStates.Idle);
        }
        private IEnumerator AttackBox()
        {
            Player.DamageCaster.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            Player.DamageCaster.gameObject.SetActive(false);
        }

        public override void Update()
        {
            //AnimatorStateInfo info = Player.RendererCompo.animator.GetCurrentAnimatorStateInfo(0);
            
            //if (info.normalizedTime > 0.1f)
            //{
            //    StateMachine.ChangeState(PlayerStates.Idle);
            //}
        }

        public override void Exit()
        {
            Player.transform.GetComponentInChildren<SpriteRenderer>().enabled = true;
            Player.transform.Find("VisualAttack").gameObject.SetActive(false);
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