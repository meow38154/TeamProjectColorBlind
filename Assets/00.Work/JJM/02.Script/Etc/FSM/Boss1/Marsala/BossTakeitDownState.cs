using UnityEngine;
using DG.Tweening;
using System;

public class BossTakeitDownState : BossState
{
    public float _firstDelay;
    public float _jumpPower;
    public float _jumpTime;
    public Ease _jumpEase;
    public float _downDelay;
    public float _downSpeed;
    public Ease _downEase;
    public float _endDelay;

    public BossTakeitDownState(float firstDelay, float jumpTime, float jumpPower, Ease jumpEase, float downDelay, float downTime, Ease downEase, float endDelay)
    {
        _firstDelay = firstDelay;
        _jumpPower = jumpPower;
        _jumpTime = jumpTime;
        _jumpEase = jumpEase;
        _downDelay = downDelay;
        _downSpeed = downTime;
        _downEase = downEase;
        _endDelay = endDelay;

        PatternPlayTime = _firstDelay + _jumpTime + _downDelay + _endDelay + 0.5f;
    }

    public override void Enter()
    {
        base.Enter();

        float saveY = _bossObject.transform.position.y;

        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(_firstDelay);
        seq.AppendCallback(() => 
        { 
            _anim.SetBool("Jump", true);
            _rb.gravityScale = 0f;
        });
        seq.Append(_bossObject.transform
            .DOMoveY(_bossObject.transform.position.y + _jumpPower, _jumpTime)
            .SetEase(_jumpEase)
        );

        Transform pTransform = GameManager.Instance.Player.transform;
        seq.AppendInterval(_downDelay);

        Vector2 targetPos = new Vector2(pTransform.position.x, saveY);
        float distance = Vector2.Distance(_bossObject.transform.position, targetPos);
        float duration = distance / _downSpeed;
        seq.AppendCallback(() => 
        {
            _anim.SetBool("Jump", false);
            _anim.SetBool("Down", true);
            _bossObject.PassaveFlipX = false;
        });

        seq.Append(_bossObject.transform
            .DOMove(targetPos, duration)
            .SetEase(_downEase)
        );
        seq.AppendCallback(() => { _anim.SetBool("Down", false);
            _bossObject.PassaveFlipX = true;
            _rb.gravityScale = 4f;
        });
        seq.AppendInterval(_endDelay);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
