using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHeal : MonoBehaviour
{
    [SerializeField] private Key _key;

    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponentInChildren<HealthSystem>();
    }

    private void Update()
    {
        if (InGameManager.Instance.ManaBar.CurrentHealth >= 100)
        {
            if (Keyboard.current[_key].wasPressedThisFrame)
            {
                InGameManager.Instance.ManaBar.Somo();
                healthSystem.GetHeal(1, transform);
                SoundManager.Instance.PlaySound(6, 0.5f);
            }
        }
    }
}
