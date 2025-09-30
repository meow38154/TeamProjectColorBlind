using System;
using _00.Work.Lusalord._02.Script.Agent;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    
    [Header("Component")]
    public AgentMovement MovementCompo { get; private set; }
    
    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }
    

    private void Awake()
    {
        MovementCompo = GetComponentInChildren<AgentMovement>();
    }
    private void FixedUpdate()
    {
        SetUpMovementInput();
    }
    private void Update()
    {
        SetUpMovementInput();
    }
    
    private void SetUpMovementInput()
    {
        MovementCompo.SetMove(PlayerInput.MoveDir.x);
    }
    
}
