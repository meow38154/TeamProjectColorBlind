using System;
using UnityEngine;


[CreateAssetMenu(fileName = "BossPattrenData", menuName = "Scriptable Objects/BossPattrenData")]
public class BossPattrenData : ScriptableObject
{
    [field: SerializeField] public PatternSO[] patternSO;
}
