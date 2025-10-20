using _00.Work.Lusalord._02.Script.VisualNovel.AttributeData;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName = "SO/DialogueData/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public TextAsset jsonFile;
    public DialogueData[] dialogues;
    
    private void OnEnable()
    {
        Debug.Log(dialogues);
        if (dialogues == null && jsonFile != null)
            LoadFromJson();
    }

    public void LoadFromJson()
    {
        Debug.Assert(jsonFile != null, "json 파일이 연결되지 않았습니다.");

        string json = jsonFile.text;
        dialogues = JsonUtility.FromJson<DialogueArray>(json).dialogues;

        Debug.Log($"로드된 대화 수: {dialogues?.Length}");
    }

    [System.Serializable]
    private class DialogueArray
    {
        public DialogueData[] dialogues;
    }
}
