using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DashPatternSO", menuName = "FSM/Pattern/BossDSAttackSO")]
public class BossDSAttackSO : PatternSO
{
    public string _animName;
    public float _firstDelay;
    public float _maintenanceTime;
    public float _endDelay;

    public void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossDSAttackState(_animName, _firstDelay, _maintenanceTime, _endDelay);
    }
}

