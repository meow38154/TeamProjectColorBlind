using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "DashPatternSO", menuName = "FSM/Pattern/TakeItDown")]
public class TakeItDownPatternSO : PatternSO
{
    public override BossState BossStateData { get; set; }
    public float _firstDelay;
    public float _jumpPower;
    public float _jumpTime;
    public Ease _jumpEase;
    public float _downDelay;
    public float _downTime;
    public Ease _downEase;
    public float _endDelay;

    private void OnEnable()
    {
        BossStateData = new BossTakeitDownState(_firstDelay, _jumpTime, _jumpPower, _jumpEase, _downDelay, _downTime, _downEase, _endDelay);
    }
}
