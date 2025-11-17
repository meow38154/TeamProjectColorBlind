using UnityEngine;
using System.Collections;

public class BossJumpState : BossState
{
    private Animator _animator;
    private float _minTime;
    private float _maxTime;
    private float _animWait;
    private float _endTime;
    private float _jumpPower;
    private float _forPower;

    public BossJumpState(float min, float max, float _an, float endTime, float jumpPower, float forPower)
    {
        _maxTime = max;
        _minTime = min;
        _animWait = _an;

        _endTime = endTime;
        _jumpPower = jumpPower;
        PatternPlayTime = Random.Range(_minTime, _maxTime) + _endTime;
        _forPower = forPower;
    }

    private IEnumerator AnimationIdleChange()
    {
        _bossObject.FlipXPlayer();
        _bossObject.StartCoroutine(Anim());
        yield return new WaitForSeconds(_animWait);
        Jump();
    }

    private IEnumerator Anim()
    {
        _animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("Jump", false);
    }

    private void Jump()
    {
        _rb = _bossObject.GetComponent<Rigidbody2D>();

        GameManager instance = GameManager.Instance;

        Vector3 targetPos = instance.Player.transform.position;
        float jumpHeight = _jumpPower;
        float gravity = Mathf.Abs(Physics2D.gravity.y);

        Vector3 startPos = _bossObject.transform.position;

        float timeToPeak = Mathf.Sqrt(2 * jumpHeight / gravity);
        float totalTime = timeToPeak + Mathf.Sqrt(2 * (startPos.y + jumpHeight - targetPos.y) / gravity);

        float vx = _forPower * ((targetPos.x - startPos.x) / totalTime);
        float vy = Mathf.Sqrt(2 * gravity * jumpHeight);

        if (vx == float.NaN)
        {
            Debug.LogWarning($"{targetPos.x} {startPos.x} / {totalTime}");
            vx = 0;
        }

        Vector2 velocity = new Vector2(vx, vy);

        _rb.linearVelocity = Vector2.zero;
        _rb.AddForce(velocity, ForceMode2D.Impulse);
    }


    public override void Enter()
    {
        _animator = _bossObject.GetComponentInChildren<Animator>();
        _bossObject.StartCoroutine(AnimationIdleChange());
    }
    public override void UpdateState() 
    {
    }
    public override void Exit() { }
}
