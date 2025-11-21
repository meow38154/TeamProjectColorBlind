using UnityEngine;
using DG.Tweening;

public class BossVectorMoveState : BossState
{
    public bool _flip;
    public float _firstDelay;
    public float _moveTime;
    public Vector3 _targetPos;
    public float _time;
    public TargetFollow _targetFollow;
    public float _endDelay;
    Sequence seq;

    public BossVectorMoveState(float first, float main, Vector3 targetPos, float time, float endDelay, bool flip)
    {
        _firstDelay = first;
        _moveTime = main;
        _endDelay = endDelay;
        _time = time;
        PatternPlayTime = first + endDelay + main;
        _targetPos = targetPos;
        _flip = flip;
    }

    public override void Enter()
    {
        _targetFollow = _bossObject.GetComponent<TargetFollow>();
        _targetFollow.Move = false;
        if (_flip )
        _bossObject.PassaveFlipX = false;
        _anim.SetBool("Dash", true);
        seq = DOTween.Sequence();
        seq.AppendInterval(_firstDelay);
        seq.Append(_bossObject.transform.DOMove(_bossObject.transform.position + _targetPos, _moveTime));
        seq.AppendInterval(_time);
        seq.Append(_bossObject.transform.DOMoveY(5.7f, _moveTime));
        seq.AppendCallback(() =>
        {
            if (_flip )
            _bossObject.PassaveFlipX = true;
            _targetFollow.Move = true;
            _anim.SetBool("Dash", false);
        });
    }
    public override void UpdateState() { }
    public override void Exit() { seq.Kill(); _anim.SetBool("Dash", false); }
    public override void Test() { }
}
