using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    [SerializeField] private bool dontDestroyOnLoad;
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
                if (instance == null)
                {
                    GameObject newInstance = new GameObject();
                    instance = newInstance.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this as T;
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
         
    }
}
