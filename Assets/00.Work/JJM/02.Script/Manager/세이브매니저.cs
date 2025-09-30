using 장준민;
using System.Collections;
using UnityEngine;

namespace 장준민
{
    public class 세이브매니저 : MonoBehaviour
    {
        [SerializeField] private 게임세이브데이터 _data;
        private string _fileName = "세이브데이터";

        private void Awake()
        {
            if (PlayerPrefs.GetString(_fileName) != "")
            {
                string json = PlayerPrefs.GetString(_fileName);
                _data = JsonUtility.FromJson<게임세이브데이터>(json);
            }

            else
            {
                _data = new 게임세이브데이터();
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
