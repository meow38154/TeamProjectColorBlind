using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.StoryData;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story.SO
{
    [CreateAssetMenu(fileName = "BackgroundDatabaseSO", menuName = "SO/Story/BackgroundDatabaseSO", order = 0)]
    public class BackgroundDatabaseSO : ScriptableObject
    {
        public List<CharacterExpression> backgrounds = new List<CharacterExpression>();

        public Sprite GetBackGround(string key)
        {
            foreach (var bg in backgrounds)
            {
                if (bg.key == key) 
                    return bg.sprite;
            }
            return null;
        }
    }
}