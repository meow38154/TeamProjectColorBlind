using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera enemyCamera;
    
    private void Awake()
    {
        enemyCamera.transform.position = mainCamera.transform.position;
        enemyCamera.orthographicSize = mainCamera.orthographicSize;
    }
}
