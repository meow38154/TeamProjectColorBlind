using UnityEngine;
using UnityEngine.InputSystem;

public class Marsala : Boss
{
    [SerializeField] private string[] phase1Patterns;
    [SerializeField] private string[] phase2Patterns;

    private void Awake()
    {
        BossBrainUpdate();
    }
    private void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            PatternsPlay(phase1Patterns, 1);
        }
    }
}
