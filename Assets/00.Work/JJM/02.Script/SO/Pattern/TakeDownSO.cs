using DG.Tweening;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TakeDownSO", menuName = "FSM/Pattern/TakeDownSO")]
public class TakeDownSO : PatternSO
{
    public float _firstDelay;
    public float _jumpPower;
    public float _jumpTime;
    public Ease _jumpEase;
    public float _downDelay;
    public float _downTime;
    public Ease _downEase;
    public float _endDelay;

    public void OnEnable()
    {
        BossStateData = new BossTakeitDownState(_firstDelay, _jumpTime, _jumpPower, _jumpEase, _downDelay, _downTime, _downEase, _endDelay);
    }
}
