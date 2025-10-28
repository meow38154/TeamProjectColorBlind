using UnityEngine;
using DG.Tweening;
using System;

public class BossStingState : BossState
{
    Sequence seq;

    public float _firstDelay;
    public float _dashTime;
    public float _dashDistance;
    public float _endDelay;

    public BossStingState(float firstDelay, float dashTime, float dashDistance, float endDelay)
    {
        _firstDelay = firstDelay;
        _dashTime = dashTime;
        _dashDistance = dashDistance;
        _endDelay = endDelay;

        PatternPlayTime = _firstDelay + _dashTime + endDelay;
    }

    public override void Enter()
    {

        Debug.Log("대쉬 공격 시작");
        base.Enter();

        seq = DOTween.Sequence();
        seq.AppendInterval(_firstDelay);
        seq.Append(_bossObject.transform.DOMoveX(_bossObject.transform.position.x + _dashDistance * GameManager.Instance.TargetAndPlayerDirectionValue(_bossObject.transform), _dashTime));
        seq.AppendInterval(_endDelay);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
        seq.Kill();
    }
}
