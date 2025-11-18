using UnityEngine;

[CreateAssetMenu(fileName = "BossVectorMoveState", menuName = "SO/FSM/BossVectorMoveState")]
public class BossVectorMoveSO : PatternSO
{
    public float _firstDelay;
    public float _moveTime;
    public Vector3 _targetPos;
    public float _time;
    public float _endDelay;

    public void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossVectorMoveState(_firstDelay, _moveTime, _targetPos, _time, _endDelay);
    }
}
