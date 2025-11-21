using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.StoryData;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story.SO
{
    [CreateAssetMenu(fileName = "CharDefinSO", menuName = "SO/Story/CharDefinSO", order = 0)]
    public class CharacterDefinition : ScriptableObject
    {
        public string characterId;
        public string displayName;
        
        public Sprite sprite;
        public List<CharacterExpression> expressions;
        
        public Sprite GetExpressionSprite(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return sprite;
            }

            foreach (var exp in expressions)
            {
                if(exp.key == key) 
                    return exp.sprite;
            }
            return sprite;
        }
    }
}