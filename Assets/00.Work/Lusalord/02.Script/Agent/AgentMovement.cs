
using System;
using System.Collections;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentMovement : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _par1;
        [Header("PlayerMovement")]      
        public float moveSpeed;
        public float jumpPower;
        
        public float dashPower;
        public float dashDuration;
        public float dashCoolTime;
        
        public bool isDash;

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
            if (isDash)
            {
                _par1.Play();
            }
        }
        
        public void SetMove(float xMove)    
        {
            XMove = xMove;
        }
        
        public void MoveAgent()
        {
            if(isDash) return;
            Debug.Log(XMove);
            Rb.linearVelocityX = XMove * moveSpeed;
        }
        
        public void Jump(float multiplier = 1f)
        {
            if(isDash) return;
            Rb.linearVelocity = Vector2.zero;
            
            Rb.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
        }
        public void Dash(Vector2 direction, float multiplier = 1f)
        {
            if(isDash) return;
            SoundManager.Instance.PlaySound(7, 1);
            StartCoroutine(DashCoroutine(direction, multiplier));
        }
        
        private IEnumerator DashCoroutine(Vector2 direction, float multiplier)
        {
            isDash = true; // 대쉬를 하고 있기에 true로 만든다.
            
            float gra = Rb.gravityScale; // 현재 중력 크기를 저장해둠.
            Rb.gravityScale = 0; // 현재 중력 크기를 0으로 바꿈.
            
            Rb.linearVelocity = Vector2.zero; // 움직임을 0으로 바꿔서 멈추게 만듬.
            
            Rb.AddForce(new Vector2(RenderCompo.DirRotation, 0) * (dashPower * multiplier), ForceMode2D.Impulse); 
            // AgentRender 안에 있는 좌우를 판별하는 값을 가져와서 x축의 벡터를 만들어서 AddForce로 힘을 준다.
            yield return new WaitForSeconds(dashDuration);
            Rb.gravityScale = gra; // 현재 중력 크기를 전에 저장해둔 중력 크기로 바꾸어 다시 떨어질 수 있도록 조정한다.
            isDash = false; // 대쉬가 끝났기에 false로 바꾼다
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
