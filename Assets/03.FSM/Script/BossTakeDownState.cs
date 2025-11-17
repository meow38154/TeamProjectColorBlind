using UnityEngine;
using DG.Tweening;

public class BossTakeDownState : BossState
{
    Rigidbody2D _rb;
    Sequence seq;

    float jumpPower = 12f;
    float waitMidAir = 0.5f;
    float slamTime = 0.25f;
    float timeToPeak;

    public BossTakeDownState()
    {
        _rb = _bossObject.GetComponent<Rigidbody2D>();
        timeToPeak = jumpPower / Mathf.Abs(Physics2D.gravity.y);
        PatternPlayTime = timeToPeak + waitMidAir + slamTime + 0.2f;
    }

    public override void Enter()
    {
        Transform tr = _bossObject.transform;
        Transform pTr = GameManager.Instance.Player.transform;

        float originalGravity = _rb.gravityScale;

        seq?.Kill();
        seq = DOTween.Sequence();

        _rb.gravityScale = originalGravity;
        _rb.linearVelocity = Vector2.zero;

        _rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        seq.AppendInterval(timeToPeak);

        seq.AppendCallback(() =>
        {
            _rb.gravityScale = 0;
            _rb.linearVelocity = Vector2.zero;
        });

        seq.AppendInterval(waitMidAir);

        seq.Append(tr.DOMove(pTr.position, slamTime).SetEase(Ease.InQuad));

        seq.AppendCallback(() =>
        {
            _rb.gravityScale = originalGravity;
        });
    }

    public override void Exit()
    {
        seq.Kill();
    }
}
