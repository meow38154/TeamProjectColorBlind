using UnityEngine;

[CreateAssetMenu(fileName = "PatternSO", menuName = "Scriptable Objects/PatternSO")]
public class PatternSO : ScriptableObject
{
    public virtual BossState BossStateData { get; set; }

    [field: SerializeField] public string Name { get; set; }
}
