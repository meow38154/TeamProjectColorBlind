using UnityEngine;

public class Over : MonoBehaviour
{
    public void Quit()
    {
        InGameManager.Instance.ScenePlay("Start");
    }
}
