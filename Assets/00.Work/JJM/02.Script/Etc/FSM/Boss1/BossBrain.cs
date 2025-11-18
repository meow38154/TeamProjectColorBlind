using UnityEngine;

public class BossBrain : MonoBehaviour
{
    [SerializeField] private Boss _bossObject;
    [SerializeField] private BossState _bossStage;
    [field: SerializeField] public BossPattrenData PattrenData { get; private set; }
    public BossStateMachine StateMachine { get; private set; }
    private void Awake()
    {
        StateMachine = new BossStateMachine();
        foreach (var pattern in PattrenData.patternSO)
        {
            StateMachine.AddState(pattern.Name, pattern.BossStateData);
            if (pattern.BossStateData._bossObject == null)
            {
                pattern.BossStateData.Initialize(pattern.BossStateData, GetComponent<Boss>());
            }
        }
    }
    public void PatternPlay(string patternName)
    {
        StateMachine.ChangeState(patternName);
    }
}
