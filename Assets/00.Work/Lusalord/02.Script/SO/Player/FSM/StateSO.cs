using _00.Work.Lusalord._02.Script.Player.FSMSystem;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

[CreateAssetMenu(fileName = "StateSO", menuName = "SO/StateSO")]
public class StateSO : ScriptableObject
{
    public string ClassName;
    public PlayerStates State;
    public AnimatorParameterSO StateParam;
}
