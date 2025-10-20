using UnityEngine;

[CreateAssetMenu(fileName = "PattonSO", menuName = "Scriptable Objects/PattonSO")]
public class PattonSO : ScriptableObject
{
    [field: SerializeField] public string SkillName { get; private set; }
    [field: SerializeField] public float FirstDeal { get; private set; }
    [field: SerializeField] public float EndDeal { get; private set; }
}
