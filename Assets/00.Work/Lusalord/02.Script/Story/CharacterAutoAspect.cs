using UnityEngine.UI;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story
{
    public class CharacterAutoAspect : MonoBehaviour
    {
        private Image _img;
        private RectTransform _rt;

        private Sprite _lastSprite;

        private void Awake()
        {
            _img = GetComponent<Image>();
            _rt = GetComponent<RectTransform>();
        }

        private void Update()
        {
            // Sprite가 바뀌었는지 체크
            if (_img.sprite != _lastSprite)
            {
                _lastSprite = _img.sprite;
                ApplyAspect();
            }
        }

        private void ApplyAspect()
        {
            if (_img.sprite == null)
                return;

            float w = _img.sprite.rect.width;
            float h = _img.sprite.rect.height;

            if (h == 0)
                return;

            float ratio = w / h;

            // 현재 부모 높이에 맞춰 자동 조정
            RectTransform parent = _rt.parent as RectTransform;
            if (parent == null)
                return;

            float parentHeight = parent.rect.height;
            float parentWidth = parent.rect.width;

            // 부모 안에서 Fit In Parent와 비슷한 방식으로 비율 맞추기
            float candidateWidth = parentHeight * ratio;
            float candidateHeight = parentHeight;

            // 만약 가로가 부모를 넘으면 → 가로에 맞춰 재조정
            if (candidateWidth > parentWidth)
            {
                candidateWidth = parentWidth;
                candidateHeight = parentWidth / ratio;
            }

            _rt.sizeDelta = new Vector2(candidateWidth, candidateHeight);
        }
    }
}