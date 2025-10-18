using _00.Work.Lusalord._02.Script.VisualNovel.AttributeData;
using UnityEngine;

[CreateAssetMenu(fileName = "AttributeDataSO", menuName = "SO/AttributeData/AttributeDataSO")]
public class AttributeDataSO : ScriptableObject
{
    public TextAsset jsonFile;
    public AttributeData attributeData;
    private void OnEnable()
    {
        // 실행 시 자동으로 로드
        if (attributeData == null && jsonFile != null)
            LoadFromJson();
    }
    
    
    public void LoadFromJson()
    {
        Debug.Assert(jsonFile == null, "json 파일이 존재하지 않음");
        
        string json = jsonFile.text;
        attributeData = JsonUtility.FromJson<AttributeData>(json);
    }
}
