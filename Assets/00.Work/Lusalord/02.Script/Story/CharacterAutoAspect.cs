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
        
        public float sizeMultiplier = 1.0f;

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
            if (_img.sprite == null)
                return;

            float w = _img.sprite.rect.width;
            float h = _img.sprite.rect.height;
            float ratio = h / w;

            RectTransform parent = _rt.parent as RectTransform;
            if (parent == null)
                return;

            // 부모 너비를 기준으로 크기 계산
            float baseWidth = parent.rect.width;
            float calcHeight = baseWidth * ratio;

            // JSON scale + sizeMultiplier 적용
            baseWidth *= sizeMultiplier;
            calcHeight *= sizeMultiplier;

            // 최대 높이 초과 시 재조정
            if (calcHeight > maxHeight)
            {
                calcHeight = maxHeight;
                baseWidth = maxHeight / ratio;
            }

            // 최종 크기 적용
            _rt.sizeDelta = new Vector2(baseWidth, calcHeight);
        }
        public void SetScale(float scale)
        {
            sizeMultiplier = scale;
            ApplyAspect();
        }
    }
}