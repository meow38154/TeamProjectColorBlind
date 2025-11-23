using System;
using System.Collections.Generic;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story.StoryData
{
    [Serializable]
    public class StoryLineData
    {
        public string choiceText;
        public string nextSequence;
    }
    [Serializable]
    public class StoryLine
    {
        public string speakerId;
        public string text;

        public string position;
        public string expressionKey;
        
        public MultiCharacterPositionData[] positions; // 복수 캐릭터용

        public string backgroundKey;
        public bool hideOthers;

        public string eventTag;
        public string effectTag;

        public StoryLineData[] choices;
        
        public float scale = 1f;
    }
    [Serializable]
    public class MultiCharacterPositionData
    {
        public string pos;           // Left, Center, Right
        public string speakerId;     // 캐릭터 ID
        public string expressionKey; // 표정 Key
    }
    [Serializable]
    public class StorySequence
    {
        public string sequenceId;
        public List<StoryLine> lines;
        public string endScene;
    }
    [Serializable]
    public class StorySequenceList
    {
        public List<StorySequence> sequences;
    }
    [Serializable]
    public class CharacterExpression
    {
        public string key;
        public Sprite sprite;
    }
    
}