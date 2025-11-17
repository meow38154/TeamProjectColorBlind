using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>();
                if (_instance == null)
                {
                    GameObject newInstance = new GameObject(typeof(T).Name);
                    _instance = newInstance.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        T[] managers = FindObjectsByType<T>(FindObjectsSortMode.None);
        if (managers.Length > 1)
            Destroy(gameObject);
         
    }
    private void OnDestroy()
    {
        if(_instance == this)
            _instance = null;
    }
}
