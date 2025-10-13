using UnityEngine;

[CreateAssetMenu(fileName = "BossPattenData", menuName = "Scriptable Objects/BossPattenData")]
public class BossPattenData : ScriptableObject
{
    [field: SerializeField] public PattonSO[] pattonSO;
}
