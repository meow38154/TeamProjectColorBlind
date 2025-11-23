using System;
using System.IO;
using JJM;
using UnityEngine;


namespace JJM
{
    [Serializable]

    public class SaveData
    {
        public bool[] itemSetting = new bool[5];
        [Range(-100f, 0f)]
        public float colorBlindness = -100;
        public int useItem = 0;
        public float soundSetting = 1;
    }
}