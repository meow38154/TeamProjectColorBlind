using _00.Work.Lusalord._02.Script.Agent;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Component
            private Animator _animator;
            private Player _player;
        #endregion

        #region Hash
            private readonly int _moveXHash = Animator.StringToHash("MoveX"); // 플레이어의 X좌표 움직임
            private readonly int _moveYHash = Animator.StringToHash("MoveY"); // 플레이어의 Y좌표 움직임
            private readonly int _isGroundHash = Animator.StringToHash("IsGround");// 플레이어가 땅에 닿았는지 체크
            private readonly int _dashHash = Animator.StringToHash("Dash");
            
            
        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>(); // Visual의 Animator를 가져옴
            _player = GetComponentInParent<Player>(); // 부모인 Player를 가져옴
        }

        private void FixedUpdate()
        {
            SetAnimation(_player.MovementCompo); 
        }

        private void SetAnimation(AgentMovement movement) // 애니메이션을 세팅하는 메서드
        {
            _animator.SetFloat(_moveXHash, Mathf.Abs(movement.Rb.linearVelocityX)); // X값을 절대값으로 받아와 
            _animator.SetFloat(_moveYHash, movement.Rb.linearVelocityY);
            _animator.SetBool(_isGroundHash, movement.IsGrounded);
        }
    }
}


