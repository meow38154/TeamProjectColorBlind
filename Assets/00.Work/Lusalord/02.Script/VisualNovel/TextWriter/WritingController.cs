using _00.Work.Lusalord._02.Script.VisualNovel.AttributeData;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.VisualNovel
{
    public class WritingController : MonoBehaviour
    {
        [SerializeField] private AttributeDataSO attributeDataSO;

        private int _index;

        public AttributeDataLine GetCurrentLine()
        {
            Debug.Assert(!attributeDataSO || attributeDataSO.attributeData == null, "SO 또는 Data가 존재하지 않습니다.");

            if (attributeDataSO.attributeData != null)
            {
                var list = attributeDataSO.attributeData.attributeDataList;
                if (_index < 0 || _index >= list.Count)
                    return null;

                return list[_index];
            }

            return null;
        }
        
        public void NextText()
        {
            _index++;
        }
        
        public bool IsFinished()
        {
            if (attributeDataSO == null || attributeDataSO.attributeData == null)
                return true;

            return _index >= attributeDataSO.attributeData.attributeDataList.Count;
        }
        
        public void ResetDialogue()
        {
            _index = 0;
        }
        
    }
}
