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
            // 스프라이트 변경 체크
            if (_img.sprite == _lastSprite) return;
            _lastSprite = _img.sprite;
            ApplyAspect();
        }

        public void ApplyAspect()
        {
            if (!_img.sprite)
                return;

            // 스프라이트 가로/세로 값
            float w = _img.sprite.rect.width;
            float h = _img.sprite.rect.height;

            if (w <= 0)
                return;

            // 세로형 캐릭터 이미지의 비율
            float ratio = h / w; // 예: 1035/424 ≈ 2.44

            // 부모 RectTransform 기준
            RectTransform parent = _rt.parent as RectTransform;
            if (parent == null) return;

            // 부모 가로를 기준으로 맞춤
            float parentWidth = parent.rect.width;

            float targetWidth = parentWidth;
            float targetHeight = targetWidth * ratio;

            // 최종 UI 크기 적용
            _rt.sizeDelta = new Vector2(targetWidth, targetHeight);
        }
    }
}