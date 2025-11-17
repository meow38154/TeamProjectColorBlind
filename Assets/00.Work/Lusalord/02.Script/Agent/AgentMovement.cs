
using System;
using System.Collections;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentMovement : MonoBehaviour
    {

        [Header("PlayerMovement")]      
        public float moveSpeed;
        public float jumpPower;
        
        public float dashPower;
        public float dashDuration;
        public float dashCoolTime;
        
        public bool isDash;
        private bool isDashCoolTime;
        private bool _canAirDash = true;

        private float XMove;
        
        [Header("GroundCheck")] 
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private Vector2 groundCheckerSize;
        
        [field:SerializeField] public bool IsGrounded { get; private set; }
        

        [Header("Component")]
        public Rigidbody2D Rb { get; private set; }
        [field:SerializeField] public AgentRenderer RenderCompo { get; private set; }
        
        private void Awake()
        {
            try
            {
                Rb = GetComponentInParent<Rigidbody2D>();
                if (Rb == null)
                    throw new MissingComponentException("Rb가 없습니다!");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[AgentMovement] Awake Error: {e.Message}");
            }
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
            if(isDash) return;
            Rb.linearVelocityX = XMove * moveSpeed;
        }
        
        public void Jump(float multiplier = 1f)
        {
            Rb.linearVelocity = Vector2.zero;
            
            Rb.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
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
