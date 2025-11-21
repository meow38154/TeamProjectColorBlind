using System.Collections;
using UnityEngine;

public class BossPatternSmokeState : BossState
{
    public EachPatternSetting[] _patternSO;

    public Coroutine _coroutine;

    public BossPatternSmokeState(EachPatternSetting[] _pattern)
    {
        _patternSO = _pattern;
        foreach (var i in _patternSO)
        {
            i._pattern.SettingUpdate();
            PatternPlayTime += i._firstDelay + i._pattern.BossStateData.PatternPlayTime;
        }
    }

    public override void Enter()
    {
        _coroutine = _bossObject.StartCoroutine(PatternsPlay());
    }
    private IEnumerator PatternsPlay()
    {
        foreach (var i in _patternSO)
        {
            yield return new WaitForSeconds(i._firstDelay);

            if (i._pattern.BossStateData._bossObject == null)
            {
                i._pattern.BossStateData.Initialize(i._pattern.BossStateData, _bossObject);
            }

            i._pattern.BossStateData.Enter();

            yield return new WaitForSeconds(i._pattern.BossStateData.PatternPlayTime);
        }
    }


    public override void UpdateState()
    {
    }
    public override void Exit() { _bossObject.StopCoroutine(_coroutine); }
}
