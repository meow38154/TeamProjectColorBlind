using DG.Tweening;
using UnityEngine;
using System.Collections;

public class BossRandomMoveState : BossState
{
    public float _firstDelay;
    public float _moveSpeed;
    public Ease _ease;
    public float _endDelay;

    public LineRenderer _lineRenderer;
    Sequence seq;

    public BossRandomMoveState(float firstDelay, float moveSpeed, Ease ease, float endDelay)
    {
        _moveSpeed = moveSpeed;
        _ease = ease;
        _endDelay = endDelay;

        PatternPlayTime = _firstDelay + _moveSpeed + _endDelay;
        _firstDelay = firstDelay;

    }

    private Vector2 _target;

    public override void Enter()
    {
        _lineRenderer = _bossObject.GetComponent<LineRenderer>();
        _bossObject.StartCoroutine(Line());
        seq = DOTween.Sequence();

        if (_bossObject.transform.position.x > 0)
        {
            _target = new Vector2(Random.Range(-0.1f, -8f), Random.Range(3f, 8f));
            _lineRenderer.SetPosition(1, _target);

        }

        if (_bossObject.transform.position.x < 0)
        {
            _target = new Vector2(Random.Range(0.1f, 8f), Random.Range(3f, 8f));
            _lineRenderer.SetPosition(1, _target);
        }

        seq.AppendCallback(() =>
        {
            _anim.SetBool("Wait", true);
        });
        seq.AppendInterval(_firstDelay);
        seq.AppendCallback(() =>
        {
            _anim.SetBool("Wait", false);
        });

        seq.AppendCallback(() =>
            {
                _anim.SetBool("Move", true);
            });

        seq.Append
        (
            _bossObject.transform.DOMove(
            _target,
            _moveSpeed).SetSpeedBased()
        );


        seq.AppendCallback(() =>
        {
            _anim.SetBool("Move", false);
        });

        seq.AppendInterval(_endDelay);

    }

    private IEnumerator Line()
    {
        while (true)
        {
            _lineRenderer.SetPosition(0, _bossObject.transform.position);
            
            yield return null;
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        _anim.SetBool("Move", false);
        base.Exit();
        seq.Kill();
    }
}
