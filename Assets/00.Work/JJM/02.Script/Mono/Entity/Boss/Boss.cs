using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Boss : MonoBehaviour
{
    private Boss1StateMachine _stateMachine;

    public Boss1State _boss1State => _stateMachine.CurrentState;

    private void Awake()
    {
        _stateMachine = new Boss1StateMachine();
    }

    private void Start()
    {
        
    }
}
