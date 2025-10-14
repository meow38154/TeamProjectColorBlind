using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentRenderer : MonoBehaviour
    {
        public int FaceDir { get; private set; }
        public bool IsFacingRight()
        {
            return Mathf.Approximately(transform.eulerAngles.y, 0);
        }
        public void FaceDirection(Vector2 mousePos) // 플레이어의 마우스가 바라보는 방향으로 캐릭터가 바라보도록 설정함
        {
            if (transform.position.x < mousePos.x) // 오른쪽
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                FaceDir = 1;
            }
            else if (transform.position.x > mousePos.x) // 왼쪽
            {
                transform.eulerAngles = Vector3.zero;
                FaceDir = -1;
            }
        }
    }
}
