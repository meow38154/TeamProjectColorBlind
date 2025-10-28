using UnityEngine;
using UnityEngine.InputSystem;

public class HealthTest : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            healthSystem.GetDamage(1);
        }
    }
}
