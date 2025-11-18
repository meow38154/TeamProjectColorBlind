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
    public TargetFollow targetF;

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

        if (_bossObject.TryGetComponent<TargetFollow>(out TargetFollow tar))
        {
            targetF = tar;
        }

        if (targetF != null)
        {
            targetF.Move = false;
        }

        bool good = false;
        Debug.Log("대쉬 공격 시작");
        base.Enter();
            _anim.SetBool("Dash", true);
        if (_bossObject.PassaveFlipX == true)
        {
            _bossObject.PassaveFlipX = false;
            good = true;
        }
        seq = DOTween.Sequence();
        seq.AppendInterval(_firstDelay);
        seq.Append(_rb.DOMoveX(_bossObject.transform.position.x + _dashDistance * GameManager.Instance.TargetAndPlayerDirectionValue(_bossObject.transform), _dashTime));
        seq.AppendCallback(() => 
        { 
                _anim.SetBool("Dash", false);
            if (_bossObject.PassaveFlipX == false && good == true)
            {
                _bossObject.PassaveFlipX = true;
            }
        });
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
