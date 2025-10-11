using _00.Work.Lusalord._02.Script.Player;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Component
        private Animator _animator;
        private Player _player;
    #endregion

    #region Hash
        private readonly int _moveXHash = Animator.StringToHash("MoveX");
        private readonly int _moveYHash = Animator.StringToHash("MoveY");
    #endregion
    
    private void SetAnimation()
    {
        
    }
}


