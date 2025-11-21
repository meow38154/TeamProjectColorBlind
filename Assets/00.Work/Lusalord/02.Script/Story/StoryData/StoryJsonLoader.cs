using _00.Work.Lusalord._02.Script.Story.SO;
using _00.Work.Lusalord._02.Script.Story.StoryData;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.VisualNovel.DialogueData
{
    public static class StoryJsonLoader
    {
        public static StorySequenceList Load(JsonStoryAssetSO assetSo)
        {
            string jsonText = assetSo.jsonFile.text;
            StorySequenceList story = JsonUtility.FromJson<StorySequenceList>(jsonText);
            
            return story;
        }
    }
}