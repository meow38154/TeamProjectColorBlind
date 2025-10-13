using UnityEngine;

[CreateAssetMenu(fileName = "PattonSO", menuName = "Scriptable Objects/PattonSO")]
public class PattonSO : ScriptableObject
{
    [field: SerializeField] public float FirstDeal;
    [field: SerializeField] public float EndDeal;
}
