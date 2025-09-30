using System;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentMovement : MonoBehaviour
    {
        public float moveSpeed;
        public Vector2 jumpPower;
    
        protected float XMove;
    
        public Rigidbody2D Rb { get; private set; }

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
        
        public void Jump(float multiplier)
        {
            Rb.linearVelocity = Vector2.zero;
            
            Rb.AddForce(Vector2.up * jumpPower * multiplier, ForceMode2D.Impulse);
        }
    }
}
