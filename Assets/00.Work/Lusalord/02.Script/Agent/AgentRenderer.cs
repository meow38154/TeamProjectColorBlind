using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Agent
{
    public class AgentRenderer : MonoBehaviour
    {
        public int DirRotation { get; private set; }
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
