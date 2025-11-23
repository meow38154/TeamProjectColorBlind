using DG.Tweening;
using UnityEngine;
[CreateAssetMenu(fileName = "DashPatternSO", menuName = "FSM/Pattern/SlimeJump")] 
public class JumpPatternSO : PatternSO 
{ 
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;
    [SerializeField] private float _animWait;
    [SerializeField] private float _endTime;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _forPower;

    [Header("Sound")]
    [SerializeField] private int _sound;
    private void OnEnable() 
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossJumpState(_minTime, _maxTime, _animWait, _endTime, _jumpPower, _forPower, _sound);
    }
}