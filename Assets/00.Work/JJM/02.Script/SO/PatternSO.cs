using UnityEngine;

[CreateAssetMenu(fileName = "PatternSO", menuName = "Scriptable Objects/PatternSO")]
public class PatternSO : ScriptableObject
{
    [field: SerializeField] public string PatternName { get; private set; }

    public virtual Boss1State Boss1StageData { get; set; }

    [field: SerializeField] public string Name { get; set; }
}
