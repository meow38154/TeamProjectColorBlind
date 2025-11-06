using UnityEngine;
using System.Collections;

public class BossJumpState : BossState
{
    private Animator _animator;
    private float _minTime;
    private float _maxTime;
    private Rigidbody2D _rb;

    public BossJumpState(float min, float max)
    {
        _maxTime = max;
        _minTime = min;

        PatternPlayTime = Random.Range(_minTime, _maxTime) + 0.5f;
    }

    private IEnumerator AnimationIdleChange()
    {
        _bossObject.FlipXPlayer();
        _animator.SetBool("Jump", true);
        yield return new WaitForSeconds(0.5f);
        Jump();
        _animator.SetBool("Jump", false);
    }

    private void Jump()
    {
        _rb = _bossObject.GetComponent<Rigidbody2D>();

        GameManager instance = GameManager.Instance;

        float playerDistanceX = instance.Player.transform.position.x - _bossObject.transform.position.x;
        float playerDistanceY = instance.Player.transform.position.y - _bossObject.transform.position.y + 6;

        Vector2 dir = new Vector2(
            instance.TargetAndPlayerDirectionValue(_bossObject.transform) *
            Mathf.Abs(playerDistanceX) * 1.3f, 
            Mathf.Abs(playerDistanceY) * 2.5f);


        _rb.AddForce(dir, ForceMode2D.Impulse);
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
