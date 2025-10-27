using System;
using System.Collections;
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
        public float dashDuration;
        public float dashCoolTime;
        
        public bool isDash;
        public bool isDashCoolTime;

        private float XMove;

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
        [field:SerializeField] public AgentRenderer RenderCompo { get; private set; }

        #endregion
        
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
        
        public void Dash(Vector2 direction, float multiplier = 1f)
        {
            if(isDash) return;
            StartCoroutine(DashCoroutine(direction, multiplier));
        }

        private IEnumerator DashCoroutine(Vector2 direction, float multiplier)
        {
            isDash = true;
            
            float gra = Rb.gravityScale;
            Rb.gravityScale = 0;
            
            Rb.linearVelocity = Vector2.zero;
            
            Rb.AddForce(new Vector2(RenderCompo.DirRotation, 0) * (dashPower * multiplier), ForceMode2D.Impulse);

            yield return new WaitForSeconds(dashDuration);
            Rb.gravityScale = gra;
            isDash = false;
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
            if(isDash) return;
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
