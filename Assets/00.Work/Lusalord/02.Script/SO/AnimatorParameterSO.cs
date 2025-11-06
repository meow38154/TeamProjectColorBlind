using UnityEngine;

namespace _00.Work.Lusalord._02.Script.SO
{
    [CreateAssetMenu(fileName = "AnimatorParameterSO", menuName = "SO/Animation/AnimatorParameterSO")]
    public class AnimatorParameterSO : ScriptableObject
    {
        [field: SerializeField] public string ParameterName { get; private set; }
        [field: SerializeField] public int HashValue { get; private set; }

        private void OnValidate()
        {
            HashValue = Animator.StringToHash(ParameterName);
        }
    }
}
