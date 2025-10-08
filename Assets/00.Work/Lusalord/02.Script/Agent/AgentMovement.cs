using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentMovement : MonoBehaviour
    {
        #region PlayerMovement

        [Header("PlayerMovement")]      
        public float moveSpeed;
        public float jumpPower;
        public float dashPower;
        
        protected float XMove;

        #endregion
        
        #region GroundCheck
        
        [Header("GroundCheck")] 
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector2 groundCheckerSize;
        
        public bool IsGrounded { get; private set; }
        
        #endregion
        
        #region Component

        [Header("Component")]
        public Rigidbody2D Rb { get; private set; }

        #endregion
        
        private void Awake()
        {
            Rb = GetComponentInParent<Rigidbody2D>();
        }
                
        private void FixedUpdate()
        {
            IsGrounded = CheckGround();
            MoveAgent();
        }
        
        public void SetMove(float xMove)    
        {
            XMove = xMove;
        }
        
        public void MoveAgent()
        {
            Rb.linearVelocityX = XMove * moveSpeed;
        }
        
        public void Jump(float multiplier = 1f)
        {
            Rb.linearVelocity = Vector2.zero;
            
            Rb.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
        }
        
        public void Dash(Vector2 direction, float multiplier = 1f)
        {
            Rb.AddForce(direction * dashPower, ForceMode2D.Impulse);
        }
        
        private bool CheckGround()
        {
            Collider2D cd = Physics2D.OverlapBox(
                transform.position, 
                groundCheckerSize, 
                0, 
                groundLayer);
            return cd;
        }

        public void AddGravityForce(Vector2 force)
        {
            Rb.AddForce(force, ForceMode2D.Force);
        }

   
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()     
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, groundCheckerSize);
        }
#endif
    }
}
