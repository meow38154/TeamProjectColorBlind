using UnityEngine;

[CreateAssetMenu(fileName = "DashPatternSO", menuName = "FSM/Pattern/DashPatternSO")]
public class DashPatternSO : PatternSO
{
    [field: SerializeField] public float firstDelay { get; private set; }
    [field: SerializeField] public float dashTime { get; private set; }
    [field: SerializeField] public float dashDistance { get; private set; }
    [field: SerializeField] public float endDelay { get; private set; }

    public void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossStingState(firstDelay, dashTime, dashDistance, endDelay);
    }
}
