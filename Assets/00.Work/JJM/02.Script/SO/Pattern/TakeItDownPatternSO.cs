using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "DashPatternSO", menuName = "FSM/Pattern/SlimeJump")]
public class JumpPatternSO : PatternSO
{

    [SerializeField] private float _minTime = 2f;
    [SerializeField] private float _maxTime = 4f;

    private void OnEnable()
    {
        BossStateData = new BossJumpState(_minTime, _maxTime);
    }
}
