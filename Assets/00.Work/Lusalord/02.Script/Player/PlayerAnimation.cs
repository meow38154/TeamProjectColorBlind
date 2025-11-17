using System;
using _00.Work.Lusalord._02.Script.Agent;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Component
            private Animator _animator;
            private Player _player;
            private HealthSystem _health;
            
            private bool _isHit;
            [SerializeField] private float hitDuration = 0.3f;
            private float _hitTimer;
        #endregion

        #region Hash
            private readonly int _moveXHash = Animator.StringToHash("MoveX"); // 플레이어의 X좌표 움직임
            private readonly int _moveYHash = Animator.StringToHash("MoveY"); // 플레이어의 Y좌표 움직임
            private readonly int _isGroundHash = Animator.StringToHash("IsGround");// 플레이어가 땅에 닿았는지 체크
            private readonly int _doubleJump = Animator.StringToHash("CanDoubleJump");
            private readonly int _dashHash = Animator.StringToHash("Dash");
            private readonly int _hitHash = Animator.StringToHash("Hit");
            
            
        #endregion

        private void Awake()
        {
            _animator = GetComponent<Animator>(); // Visual의 Animator를 가져옴
            _player = GetComponentInParent<Player>(); // 부모인 Player를 가져옴
            _health = transform.parent.GetComponentInChildren<HealthSystem>();
        }
    }
}


