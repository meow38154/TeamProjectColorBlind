using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story.SO
{
    [CreateAssetMenu(fileName = "StorySO", menuName = "SO/Story/StorySO", order = 0)]
    public class JsonStoryAssetSO : ScriptableObject
    {
        public TextAsset jsonFile;
        public string startSequenceId = "Story1";
    }
}