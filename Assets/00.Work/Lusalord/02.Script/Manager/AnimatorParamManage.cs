using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Player.FSMSystem;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

public class AnimatorParamManage : Singleton<AnimatorParamManage>
{
    [SerializeField] private List<AnimatorParameterSO> type;
    private Dictionary<string, AnimatorParameterSO> _parameterDictionary = new();

    protected override void Awake()
    {
        base.Awake();
        foreach (AnimatorParameterSO param in type)
        {
            if (param == null || string.IsNullOrEmpty(param.ParameterName)) continue;
            _parameterDictionary[param.ParameterName] = param;
        }
    }

    public AnimatorParameterSO GetParameter(string name)
    {
        _parameterDictionary.TryGetValue(name, out var value);
        return value;
    }
    public AnimatorParameterSO GetParameter(PlayerStates name)
    {
        return GetParameter(name.ToString());
    }
}
