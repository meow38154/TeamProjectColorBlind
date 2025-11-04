using UnityEngine;

namespace _00.Work.Lusalord._02.Script.SO.Player.FSM
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "SO/FSM/Player/State", order = 0)]
    public class StateSO : ScriptableObject
    {
        public string StateName;
        public AnimatorParameterSO ParameterSO;
    }
}