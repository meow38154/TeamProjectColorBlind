using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera enemyCamera;
    
    private void Awake()
    {
        enemyCamera.orthographicSize = mainCamera.orthographicSize;
    }
}
