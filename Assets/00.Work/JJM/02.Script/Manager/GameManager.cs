using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public GameObject Player { get; private set; }

}
