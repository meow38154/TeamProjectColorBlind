using UnityEngine;
using System.Collections;

public class BossJumpState : BossState
{
    private float _minTime = 2f;
    private float _maxTime = 5f;
    private Rigidbody2D _rb;

    public BossJumpState(float min, float max)
    {
        _maxTime = max;
        _minTime = min;

        PatternPlayTime = Random.Range(_minTime, _maxTime);
    }

    public override void Enter()
    {
        Debug.Log("มกวม");

        _rb = _bossObject.GetComponent<Rigidbody2D>();

        GameManager instance = GameManager.Instance;

        float playerDistanceX = instance.Player.transform.position.x - _bossObject.transform.position.x;
        float playerDistanceY = instance.Player.transform.position.y - _bossObject.transform.position.y + 6;

        Vector2 dir = new Vector2(
            instance.TargetAndPlayerDirectionValue(_bossObject.transform) *
            Mathf.Abs(playerDistanceX) * 1.3f, 
            Mathf.Abs(playerDistanceY) * 2);


        _rb.AddForce(dir, ForceMode2D.Impulse);
    }
    public override void UpdateState() 
    {
    }
    public override void Exit() { }
}
