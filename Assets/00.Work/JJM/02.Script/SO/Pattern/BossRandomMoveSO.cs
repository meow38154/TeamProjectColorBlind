using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "TakeDownSO", menuName = "FSM/Pattern/BossRandomMoveSO")]
public class BossRandomMoveSO : PatternSO
{
    public float _firstDelay;
    public float _moveSpeed;
    public Ease _ease;
    public float _endDelay;

    public void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossRandomMoveState(_firstDelay, _moveSpeed, _ease, _endDelay);
    }
}
