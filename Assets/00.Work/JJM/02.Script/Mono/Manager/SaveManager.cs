using System.IO;
using UnityEngine;

namespace JJM
{
    public class SaveManager : Singleton<SaveManager>
    {
        [SerializeField] private SaveData _data;
        private string _fileName = "SaveData.json";
        private string _filePath;

        public SaveData Data => _data;

        private void Awake()
        {

            Debug.Log(Application.persistentDataPath);
            _filePath = Path.Combine(Application.persistentDataPath, _fileName);

            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _data = JsonUtility.FromJson<SaveData>(json);
            }
            else
            {
                _data = new SaveData();
            }
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(_data, true);
            File.WriteAllText(_filePath, json);
        }

        public void Load()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _data = JsonUtility.FromJson<SaveData>(json);
            }
        }

        public void DeleteSave()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }
}
