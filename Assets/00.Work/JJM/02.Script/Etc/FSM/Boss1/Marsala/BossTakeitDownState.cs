using UnityEngine;
using DG.Tweening;
using System;

public class BossTakeitDownState : BossState
{
    public int jumpSoundNum;
    public int downSoundNum;

    public float _firstDelay;
    public float _jumpPower;
    public float _jumpTime;
    public Ease _jumpEase;
    public float _downDelay;
    public float _downSpeed;
    public Ease _downEase;
    public float _endDelay;

    Sequence seq;

    public BossTakeitDownState(float firstDelay, float jumpTime, float jumpPower, Ease jumpEase, float downDelay, float downSpeed, Ease downEase, float endDelay, int j, int d)
    {
        _firstDelay = firstDelay;
        _jumpPower = jumpPower;
        _jumpTime = jumpTime;
        _jumpEase = jumpEase;
        _downDelay = downDelay;
        _downSpeed = downSpeed;
        _downEase = downEase;
        _endDelay = endDelay;

        jumpSoundNum = j;
        downSoundNum = d;
        PatternPlayTime = _firstDelay + _jumpTime + _downDelay + _endDelay + 0.5f;
    }

    public override void Enter()
    {
        base.Enter();

        seq = DOTween.Sequence();

        seq.AppendInterval(_firstDelay);
        seq.AppendCallback(() =>
        {
            _anim.SetBool("Jump", true);
            _rb.gravityScale = 0f;
            SoundManager.Instance.PlaySound(jumpSoundNum, 0.3f);
        });

        seq.Append(_bossObject.transform
            .DOMoveY(_bossObject.transform.position.y + _jumpPower, _jumpTime)
            .SetEase(_jumpEase)
        );

        seq.AppendInterval(_downDelay);

        seq.AppendCallback(() =>
        {
            SoundManager.Instance.PlaySound(downSoundNum, 0.6f, 0.5f);

            int dir = InGameManager.Instance.TargetAndPlayerDirectionValue(_bossObject.transform);
            Vector2 targetPos = new Vector2(_bossObject.transform.position.x + dir * 4.4f, 2);

            _anim.SetBool("Jump", false);
            _anim.SetBool("Down", true);
            _bossObject.PassaveFlipX = false;

            _rb
                .DOMove(targetPos, 0.5f)
                .SetEase(_downEase)
                .OnComplete(() =>
                {
                    _anim.SetBool("Down", false);
                    _bossObject.PassaveFlipX = true;
                    _rb.gravityScale = 0f;
                });
        });
        seq.AppendCallback(() => { _rb.gravityScale = 3f; });

        seq.AppendInterval(_endDelay);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        _rb.gravityScale = 3f;
        _anim.SetBool("Down", false);
        base.Exit();
        if (seq != null) seq.Kill();
    }
}
