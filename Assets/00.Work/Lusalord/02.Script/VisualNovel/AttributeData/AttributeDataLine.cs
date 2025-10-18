using System;
using System.Collections.Generic;

namespace _00.Work.Lusalord._02.Script.VisualNovel.AttributeData
{
    [Serializable]
    public class AttributeDataLine
    {
        public string speaker;
        public string text;
        public string eventTag;
    }

    [Serializable]
    public class AttributeData
    {
        public List<AttributeDataLine> attributeDataList;
    }
}