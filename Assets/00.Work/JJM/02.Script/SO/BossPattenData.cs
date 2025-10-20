using UnityEngine;

[CreateAssetMenu(fileName = "BossPattenData", menuName = "Scriptable Objects/BossPattenData")]
public class BossPattenData : ScriptableObject
{
    [SerializeField] private int _phaseNum = 1;
    [field: SerializeField] public PattonSO[] pattonSO;
}
