using System;
using _00.Work.Lusalord._02.Script.Agent;
using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Component
        private Animator _animator;
        private Player _player;
    #endregion

    #region Hash
        private readonly int _moveXHash = Animator.StringToHash("MoveX");
        private readonly int _moveYHash = Animator.StringToHash("MoveY");
    #endregion

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }

    private void FixedUpdate()
    {
        SetAnimation(_player.MovementCompo);
    }

    private void SetAnimation(AgentMovement movement)
    {
        _animator.SetFloat(_moveXHash, Mathf.Abs(movement.Rb.linearVelocityX));
    }
}


