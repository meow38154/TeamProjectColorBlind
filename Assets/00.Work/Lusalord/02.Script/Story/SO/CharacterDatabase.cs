using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story.StoryData
{
    [CreateAssetMenu(fileName = "CharacterDatabaseSO", menuName = "SO/Story/CharDatabaseSO", order = 0)]
    public class CharacterDatabase : ScriptableObject
    {
        public List<CharacterDefinition> characters = new List<CharacterDefinition>();

        public CharacterDefinition GetCharacter(string id)
        {
            return characters.Find(x => x.characterId == id);
        }
        
    }
}