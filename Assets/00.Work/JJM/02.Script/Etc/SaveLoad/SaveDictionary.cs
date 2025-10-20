using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JJM
{
    [Serializable]
    public class SaveDictionary<K, V> : ISerializationCallbackReceiver
    {
        [SerializeField] private List<K> ks = new List<K>();
        [SerializeField] private List<V> vs = new List<V>();

        private Dictionary<K, V> _dictionary = new Dictionary<K, V>();

        public void Add(K key, V value)
        {
            _dictionary.Add(key, value);
            ks.Add(key);
            vs.Add(value);
        }

        public void Clear()
        {
            _dictionary.Clear();
            ks.Clear();
            vs.Clear();
        }

        public void OnAfterDeserialize()
        {
            _dictionary = new Dictionary<K, V>();
            for (int i = 0; i < ks.Count && i < vs.Count; i++)
            {
                _dictionary[ks[i]] = vs[i];
            }
        }

        public void OnBeforeSerialize()
        {
            ks.Clear();
            vs.Clear();
            foreach (var kv in _dictionary)
            {
                ks.Add(kv.Key);
                vs.Add(kv.Value);
            }
        }
    }
}