using System;
using _00.Work.Lusalord._02.Script.SO;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentRenderer : MonoBehaviour
    {
        public Animator animator;
        public int DirRotation { get; private set; }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void SetParameter(AnimatorParameterSO param, int value) => animator.SetInteger(param.HashValue, value);
        public void SetParameter(AnimatorParameterSO param, float value) => animator.SetFloat(param.HashValue, value);
        public void SetParameter(AnimatorParameterSO param, bool value) => animator.SetBool(param.HashValue, value);
        public void SetParameter(AnimatorParameterSO param) => animator.SetTrigger(param.HashValue);
        
        public void FaceDirection(Vector2 dir) // 플레이어의 마우스가 바라보는 방향으로 캐릭터가 바라보도록 설정함
        {
            if (dir.x > 0) // 오른쪽
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                DirRotation = 1;
            }
            else if (dir.x < 0) // 왼쪽
            {
                transform.eulerAngles = Vector3.zero;
                DirRotation = -1;
            }
        }
    }
}
