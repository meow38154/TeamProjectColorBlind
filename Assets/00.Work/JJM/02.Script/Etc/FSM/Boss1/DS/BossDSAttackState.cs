using UnityEngine;
using DG.Tweening;

public class BossDSAttackState : BossState
{
    Sequence seq;
    public string _animName;
    public float _firstDelay;
    public float _maintenanceTime;
    public TargetFollow _targetFollow;
    public float _endDelay;

    public BossDSAttackState(string anim, float first, float main, float endDelay)
    {
        _animName = anim;
        _firstDelay = first;
        _maintenanceTime = main;
        _endDelay = endDelay;

        PatternPlayTime = first + endDelay;
    }

    public override void Enter()
    {
        _targetFollow = _bossObject.GetComponent<TargetFollow>();
        _targetFollow.Move = false;
        _bossObject.PassaveFlipX = false;
        _anim.SetBool(_animName, true);
        seq = DOTween.Sequence();
        SoundManager.Instance.PlaySound(14, 0.7f);
        seq.AppendInterval(_firstDelay);
        seq.AppendCallback(() =>
        {
            InGameManager.Instance.CinemachineImpulseSource.GenerateImpulse();
        });
        seq.AppendInterval(_maintenanceTime);
        seq.AppendCallback(() =>
        {
            _bossObject.PassaveFlipX = true;
            _targetFollow.Move = true;
            _anim.SetBool(_animName, false);
        });
    }
    public override void UpdateState() { }
    public override void Exit() 
    {
        seq.Kill();
        _anim.SetBool(_animName, false);
    }
    public override void Test() { }
}
