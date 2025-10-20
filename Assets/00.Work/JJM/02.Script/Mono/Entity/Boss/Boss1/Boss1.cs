using UnityEngine;
using UnityEngine.InputSystem;

public class Boss1 : Boss
{
    public enum CurrentPhase
    {
        Phase1,
        Phase2
    }


    private void Awake()
    {
        GetSetting();
    }

    private void Update()
    {
        
    }
}
