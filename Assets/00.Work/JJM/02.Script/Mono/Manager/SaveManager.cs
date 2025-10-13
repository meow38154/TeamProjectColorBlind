using ¿Â¡ÿπŒ;
using System.Collections;
using UnityEngine;

namespace ¿Â¡ÿπŒ
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private SaveData _data;
        private string _fileName = "Save_data";

        private void Awake()
        {
            if (PlayerPrefs.GetString(_fileName) != "")
            {
                string json = PlayerPrefs.GetString(_fileName);
                _data = JsonUtility.FromJson<SaveData>(json);
            }

            else
            {
                _data = new SaveData();
            }
        }

        private void OnApplicationQuit()
        {
            string json = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString(_fileName, json);
            PlayerPrefs.Save();
        }
    }
}
