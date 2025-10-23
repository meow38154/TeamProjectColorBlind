using UnityEngine;

[CreateAssetMenu(fileName = "DashPatternSO", menuName = "Scriptable Objects/DashPatternSO")]
public class DashPatternSO : PatternSO
{
    public override Boss1State Boss1StageData { get; set; }

    private void OnEnable()
    {
        Boss1StageData = new Boss1StingState();

    }
}
