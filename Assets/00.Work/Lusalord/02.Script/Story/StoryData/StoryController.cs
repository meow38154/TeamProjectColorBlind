using System.Collections;
using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.SO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _00.Work.Lusalord._02.Script.Story.StoryData
{
    public class StoryController : MonoBehaviour
    {
        [Header("Json Story Asset")]
        [SerializeField] private JsonStoryAssetSO storyAsset;

        [Header("Databases")]
        [SerializeField] private CharacterDatabase characterDatabase;
        [SerializeField] private BackgroundDatabaseSO backgroundDatabase;

        [Header("UI")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image leftCharacterImage;
        [SerializeField] private Image centerCharacterImage;
        [SerializeField] private Image rightCharacterImage;

        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;

        [Header("Settings")]
        [SerializeField] private float lettersPerSecond = 40f;
        [SerializeField] private float fadeDuration = 0.25f;

        private StorySequenceList _storyData;
        private StorySequence _sequence;
        private int _index;
        private Coroutine _typingCo;

        private Dictionary<string, StorySequence> _seqMap;
        
        private void Start()
        {
            LoadStory();
            StartSequenceFromSO();
        }
        
        private void Update()
        {
            // 타이핑 중에서도, 대기 중에도 Space로 다음 컷 넘기기
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                ShowNext();
            }
        }
        
        private void LoadStory()
        {
            _storyData = StoryJsonLoader.Load(storyAsset);

            if (_storyData == null || 
                _storyData.sequences == null ||
                _storyData.sequences.Count == 0)
            {
                Debug.LogError("스토리 데이터가 없습니다.");
                return;
            }

            _seqMap = new Dictionary<string, StorySequence>();
            foreach (var seq in _storyData.sequences)
                _seqMap[seq.sequenceId] = seq;
        }
        
        private void StartSequenceFromSO()
        {
            if (!_seqMap.TryGetValue(storyAsset.startSequenceId, out _sequence))
            {
                Debug.LogError($"startSequenceId({storyAsset.startSequenceId})를 찾을 수 없습니다.");
                return;
            }

            _index = -1;
            ShowNext();
        }
        
        private void ShowNext()
        {
            if (_typingCo != null)
            {
                SkipTyping();
                return;
            }

            _index++;

            if (_index >= _sequence.lines.Count)
            {
                if (!string.IsNullOrEmpty(_sequence.endScene))
                {
                    SceneManager.LoadScene(_sequence.endScene);
                    return;
                }

                Debug.Log("스토리 종료");
                return;
            }

            StoryLine line = _sequence.lines[_index];

            dialogueText.gameObject.SetActive(true);

            UpdateBackground(line);
            UpdateSpeaker(line);
            UpdateCharacters(line);

            _typingCo = StartCoroutine(TypeRoutine(line.text, dialogueText));
        }
        
        private IEnumerator TypeRoutine(string full, TMP_Text ui)
        {
            ui.text = "";
            float interval = 1f / lettersPerSecond;

            for (int i = 0; i < full.Length; i++)
            {
                ui.text = full.Substring(0, i + 1);
                yield return new WaitForSeconds(interval);
            }

            _typingCo = null;
        }

        private void SkipTyping()
        {
            StoryLine line = _sequence.lines[_index];

            if (_typingCo != null)
            {
                StopCoroutine(_typingCo);
                _typingCo = null;
            }

            dialogueText.text = line.text;
        }
        
        private void UpdateSpeaker(StoryLine line)
        {
            if (string.IsNullOrEmpty(line.speakerId))
            {
                speakerText.text = "";
                return;
            }

            var c = characterDatabase.GetCharacter(line.speakerId);
            if (string.IsNullOrEmpty(c.displayName))
            {
                speakerText.text = "";
                return;
            }
            speakerText.text = c.displayName;

        }
        
        private void UpdateCharacters(StoryLine line)
        {
            // 모두 비활성화 (기본)
            leftCharacterImage.enabled = false;
            centerCharacterImage.enabled = false;
            rightCharacterImage.enabled = false;

            bool useFade = line.hideOthers;

            // 배경 컷 (None)
            if (line.position == "None" &&
                (line.positions == null || line.positions.Length == 0))
                return;

            // ▣ 복수 캐릭터 컷
            if (line.positions != null && line.positions.Length > 0)
            {
                foreach (var p in line.positions)
                {
                    var charData = characterDatabase.GetCharacter(p.speakerId);
                    Sprite sp = charData != null ? charData.GetExpressionSprite(p.expressionKey) : null;

                    if (p.pos == "Left") SetCharacterWithFade(leftCharacterImage, sp, useFade, line.scale);
                    else if (p.pos == "Center") SetCharacterWithFade(centerCharacterImage, sp, useFade, line.scale);
                    else if (p.pos == "Right") SetCharacterWithFade(rightCharacterImage, sp, useFade, line.scale);
                }

                return;
            }

            // ▣ 단일 캐릭터 컷
            var c = characterDatabase.GetCharacter(line.speakerId);
            Sprite single = c != null ? c.GetExpressionSprite(line.expressionKey) : null;

            if (line.position == "Left") SetCharacterWithFade(leftCharacterImage, single, useFade, line.scale);
            else if (line.position == "Center") SetCharacterWithFade(centerCharacterImage, single, useFade, line.scale);
            else if (line.position == "Right") SetCharacterWithFade(rightCharacterImage, single, useFade, line.scale);
        }

        private void SetCharacterWithFade(Image img, Sprite sp, bool useFade, float scale)
        {
            img.sprite = sp;

            var auto = img.GetComponent<CharacterAutoAspect>();
            if (auto != null)
                auto.ApplyAspect();

            if (sp == null)
            {
                img.enabled = false;
                return;
            }
            if (auto != null)
            {
                auto.SetScale(scale);   // 🔥 JSON scale 적용
            }
            img.enabled = true;

            if (!useFade)
            {
                // 페이드 없음 → 즉시 표시
                Color c = img.color;
                c.a = 1f;
                img.color = c;
                return;
            }

            // 페이드 있음
            StartCoroutine(FadeIn(img));
        }

        private IEnumerator FadeIn(Image img)
        {
            Color c = img.color;
            c.a = 0;
            img.color = c;

            float t = 0;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                c.a = Mathf.Lerp(0, 1, t / fadeDuration);
                img.color = c;
                yield return null;
            }

            c.a = 1;
            img.color = c;
        }

        private void UpdateBackground(StoryLine line)
        {
            if (string.IsNullOrEmpty(line.backgroundKey))
                return;

            var bg = backgroundDatabase.GetBackGround(line.backgroundKey);
            if (bg == null)
                return;

            // 페이드 없음 → 즉시 반영
            if (!line.hideOthers)
            {
                backgroundImage.sprite = bg;
                backgroundImage.color = new Color(1, 1, 1, 1);
                return;
            }

            // 페이드 있음 → 부드럽게 전환
            StopCoroutine("FadeBackground");
            StartCoroutine(FadeBackground(bg));
        }
        
        private IEnumerator FadeBackground(Sprite newSprite)
        {
            float t = 0;
            Color c = backgroundImage.color;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float a = Mathf.Lerp(1, 0, t / fadeDuration);
                backgroundImage.color = new Color(c.r, c.g, c.b, a);
                yield return null;
            }

            backgroundImage.sprite = newSprite;

            t = 0;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float a = Mathf.Lerp(0, 1, t / fadeDuration);
                backgroundImage.color = new Color(c.r, c.g, c.b, a);
                yield return null;
            }
        }
    }
}
