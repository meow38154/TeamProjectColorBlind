using System;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentMovement : MonoBehaviour
    {
        #region PlayerMovement

        [Header("PlayerMovement")]
        public float moveSpeed;
        public float jumpPower;
        
        protected float XMove;

        #endregion
        
        #region GroundCheck
        
        [Header("GroundCheck")] 
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector2 groundCheckerSize;
        
        public bool isGrounded;
        
        
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

        private void CheckGround()
        {
            Collider2D cd = Physics2D.OverlapBox(transform.position, groundCheckerSize, 0, groundLayer);
            isGrounded = cd;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, groundCheckerSize);
        }
#endif
    }
}
