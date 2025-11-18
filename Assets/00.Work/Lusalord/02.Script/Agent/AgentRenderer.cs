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
        private bool _lockAnimation = false;
        
        public bool IsAnimationFinished(string animName)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

            if (!info.IsName(animName))
                return false;

            return info.normalizedTime >= 1f;
        }

        public void SetParameter(AnimatorParameterSO param, int value)
        {
            if (_lockAnimation) return;
            animator.SetInteger(param.HashValue, value);
        }

        public void SetParameter(AnimatorParameterSO param, float value)
        {
            if (_lockAnimation) return;
            animator.SetFloat(param.HashValue, value);
        }

        public void SetParameter(AnimatorParameterSO param, bool value)
        {
            if (_lockAnimation) return;
            animator.SetBool(param.HashValue, value);
        }

        public void SetParameter(AnimatorParameterSO param)
        {
            if (_lockAnimation) return;
            animator.SetTrigger(param.HashValue);
        }
        
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
