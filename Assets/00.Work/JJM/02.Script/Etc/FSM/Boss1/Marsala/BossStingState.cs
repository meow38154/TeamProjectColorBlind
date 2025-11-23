using UnityEngine;
using DG.Tweening;
using System.Collections;

public class BossStingState : BossState
{
    Sequence seq;

    public float _firstDelay;
    public float _dashTime;
    public float _dashDistance;
    public float _endDelay;
    public TargetFollow targetF;

    private Coroutine _coroutine;

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
        _coroutine = _bossObject.StartCoroutine(AfterImage());
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
        seq.AppendCallback(() =>
        { SoundManager.Instance.PlaySound(7, 0.7f); });
            seq.Append(_rb.DOMoveX(_bossObject.transform.position.x + _dashDistance * InGameManager.Instance.TargetAndPlayerDirectionValue(_bossObject.transform), _dashTime));
        seq.AppendCallback(() => 
        { 
                _anim.SetBool("Dash", false);
            if (_bossObject.PassaveFlipX == false && good == true)
            {
                _bossObject.PassaveFlipX = true;
            }
            _bossObject.StopCoroutine(_coroutine);
        });
    }

    private IEnumerator AfterImage()
    {
        while (true)
        {
            InGameManager.Instance.Afterimage(_bossObject._spriteRenderer);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
       
        _anim.SetBool("Dash", false);
        Debug.Log("대쉬 끝");
        seq.Kill();
        base.Exit();
    }
}
