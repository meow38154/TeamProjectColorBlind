using System;
using UnityEngine;

[Serializable]
public struct EachPatternSetting
{
    public float _firstDelay;
    public PatternSO _pattern;
}

[CreateAssetMenu(fileName = "BossPatternSmokeSO", menuName = "Scriptable Objects/BossPatternSmokeSO")]
public class BossPatternSmokeSO : PatternSO
{
    public EachPatternSetting[] _patterns;

    private void OnEnable()
    {
        SettingUpdate();
    }

    public override void SettingUpdate()
    {
        BossStateData = new BossPatternSmokeState(_patterns);
    }
}
