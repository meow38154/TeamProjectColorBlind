using UnityEngine.UI;
using UnityEngine;

namespace _00.Work.Lusalord._02.Script.Story
{
    public class CharacterAutoAspect : MonoBehaviour
    {
        private Image _img;
        private RectTransform _rt;
        private Sprite _lastSprite;

        [Header("높이 제한")]
        public float maxHeight = 1200f; // 필요하면 Inspector에서 조절

        private void Awake()
        {
            _img = GetComponent<Image>();
            _rt = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (_img.sprite != _lastSprite)
            {
                _lastSprite = _img.sprite;
                ApplyAspect();
            }
        }

        public void ApplyAspect()
        {
            if (_img.sprite == null) return;

            float w = _img.sprite.rect.width;
            float h = _img.sprite.rect.height;
            float ratio = h / w;

            RectTransform parent = _rt.parent as RectTransform;
            if (parent == null) return;

            // 기본 가로 기준
            float baseWidth = parent.rect.width;
            float calcHeight = baseWidth * ratio;

            // ★ 세로가 너무 길면 자동 제한
            if (calcHeight > maxHeight)
            {
                calcHeight = maxHeight;
                baseWidth = calcHeight / ratio; // 가로도 비율 유지
            }

            _rt.sizeDelta = new Vector2(baseWidth, calcHeight);
        }
    }
}