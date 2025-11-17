using System;

namespace _00.Work.Lusalord._02.Script.Player.FSMSystem
{
    [Serializable]
    public enum PlayerStates
    {
        Idle, Move, Attack, 
        Dash, Hit, Death,
        Jump, DoubleJump, Fall
    }
}