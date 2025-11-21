using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BossUpState : BossState
{
    private float _jumpPower;
    private Ease _jumpEase;
    private float _jumpTime;
    private float _endDelay;

    private float _holdingTime;

    Sequence seq;

    public BossUpState(float jumpPower, Ease jumpEase, float jumpTime, float endDelay, float holdingTime)
    {
        _jumpEase = jumpEase;
        _jumpPower = jumpPower;
        _jumpTime = jumpTime;
        _endDelay = endDelay;
        _holdingTime = holdingTime;

        PatternPlayTime = _jumpTime + _endDelay;
    }

    private float saveGravity;

    public override void Enter()
    {
        saveGravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        seq = DOTween.Sequence();
        _anim.SetBool("Jump", true);
        seq.Append(_rb.DOMoveY(_jumpPower, _jumpTime).SetEase(_jumpEase));
        seq.AppendCallback(() => 
        { 
            _anim.SetBool("Jump", false);
            _bossObject.StartCoroutine(Time());
            _anim.SetBool("Up", true);
        });
    }

    private IEnumerator Time()
    {
        yield return new WaitForSeconds(_holdingTime);
        _anim.SetBool("Up", false);
        _rb.gravityScale = saveGravity;
        _rb.gravityScale = 3f;
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        _rb.gravityScale = 3f;
        _anim.SetBool("Up", false);
        _anim.SetBool("Jump", false);
        seq.Kill();
    }
}
