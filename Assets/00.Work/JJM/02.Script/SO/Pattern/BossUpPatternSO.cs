using DG.Tweening;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TakeDownSO", menuName = "FSM/Pattern/BossUpPatternSO")]
public class BossUpPatternSO : PatternSO
{
    public float _jumpPower;
    public Ease _jumpEase;
    public float _jumpTime;
    public float _endDelay;
    public float _holdingTime;


    public void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossUpState(_jumpPower, _jumpEase, _jumpTime, _endDelay, _holdingTime);
    }
}
