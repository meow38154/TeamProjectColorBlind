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

            _health.OnGetDamage += SetDamage;
        }
        

        private void FixedUpdate()
        {
            SetAnimation(_player.MovementCompo); 
        }

        private void SetAnimation(AgentMovement movement) // 애니메이션을 세팅하는 메서드
        {
            _animator.SetFloat(_moveXHash, Mathf.Abs(movement.Rb.linearVelocityX)); // X값을 절대값으로 받아와서 
            _animator.SetFloat(_moveYHash, movement.Rb.linearVelocityY);
            _animator.SetBool(_isGroundHash, movement.IsGrounded);
            _animator.SetBool(_doubleJump, _player._canDoubleJump);
            _animator.SetBool(_dashHash, movement.isDash);
            
        }

        private void SetDamage()
        {
            _isHit = true;
            _hitTimer = 0f;
            _animator.SetBool(_hitHash, true);
        }

        private void Update()
        {
            if (_isHit)
            {
                _hitTimer += Time.deltaTime;
                if (_hitTimer >= hitDuration)
                {
                    _isHit = false;
                    _animator.SetBool(_hitHash, false);
                }
            }
        }
    }
}


