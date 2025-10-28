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
    public float _downTime;
    public Ease _downEase;
    public float _endDelay;

    public BossTakeitDownState(float firstDelay, float jumpTime ,float jumpPower, Ease jumpEase, float downDelay, float downTime, Ease downEase, float endDelay)
    {
         _firstDelay = firstDelay;
        _jumpPower = jumpPower;
        _jumpTime = jumpTime;
        _jumpEase = jumpEase;
        _downDelay = downDelay;
        _downTime = downTime;
        _downEase = downEase;
        _endDelay = endDelay;

        PatternPlayTime = _firstDelay + _jumpTime + downDelay + _downTime + _endDelay;
    }

    public override void Enter()
    {
        Debug.Log("내려찍기 공격 활성화");

        base.Enter();

        float saveY = _bossObject.transform.position.y;

        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(_firstDelay);
        seq.Append(_bossObject.transform
        .DOMoveY(_bossObject.transform.position.y + _jumpPower, _jumpTime)
        .SetEase(_jumpEase)
        );
        Transform pTransform = GameManager.Instance.Player.transform;
        Debug.Log(pTransform.position.x);
        seq.AppendInterval(_downDelay);


        seq.Append(_bossObject.transform
        .DOMove(new Vector2(pTransform.position.x, saveY), _downTime)
        .SetEase(_downEase)
        );
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
