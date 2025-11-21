using System.Collections;
using System.Collections.Generic;
using _00.Work.Lusalord._02.Script.Story.SO;
using _00.Work.Lusalord._02.Script.VisualNovel.DialogueData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace _00.Work.Lusalord._02.Script.Story.StoryData
{
    public class StoryController : MonoBehaviour
    {
        [Header("Json SO")]
        [SerializeField] private JsonStoryAssetSO storyAsset;

        [Header("데이터베이스")]
        [SerializeField] private CharacterDatabase characterDatabase;
        [SerializeField] private BackgroundDatabaseSO backgroundDatabaseSo;

        [Header("UI - 캐릭터/배경")]
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image leftCharacterImage;
        [SerializeField] private Image centerCharacterImage;
        [SerializeField] private Image rightCharacterImage;

        [Header("대사 UI")]
        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;

        [Header("설정")]
        [SerializeField] private float lettersPerSecond = 40f;
        [SerializeField] private float fadeDuration = 0.25f;

        private StorySequenceList _storyData;
        private StorySequence _currentSequence;

        private int _index;
        private bool _waitingInput;
        private Coroutine _typingCo;

        private Dictionary<string, StorySequence> _seqMap;

        private void Start()
        {
            LoadStory();
            StartSequence("Intro");
        }

        private void Update()
        {
            if (_waitingInput && Keyboard.current.spaceKey.wasPressedThisFrame)
                ShowNext();
        }

        private void LoadStory()
        {
            _storyData = StoryJsonLoader.Load(storyAsset);
            Debug.Assert(_storyData != null, "스토리 데이터를 불러오지 못했습니다.");

            _seqMap = new Dictionary<string, StorySequence>();
            foreach (var seq in _storyData.sequences)
                _seqMap[seq.sequenceId] = seq;
        }

        private void StartSequence(string seqId)
        {
            Debug.Assert(_seqMap.TryGetValue(seqId, out _currentSequence),
                "없는 시퀀스입니다: " + seqId);

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

            if (_index >= _currentSequence.lines.Count)
            {
                // nextSequence 자동 이동
                if (!string.IsNullOrEmpty(_currentSequence.nextSequence))
                    StartSequence(_currentSequence.nextSequence);

                return;
            }

            StoryLine line = _currentSequence.lines[_index];

            dialogueText.gameObject.SetActive(true);

            UpdateBackground(line);
            UpdateSpeaker(line);
            UpdateCharacters(line);

            _typingCo = StartCoroutine(TypeRoutine(line.text, dialogueText));
        }

        private IEnumerator TypeRoutine(string full, TMP_Text ui)
        {
            _waitingInput = false;
            ui.text = "";

            float interval = 1f / Mathf.Max(lettersPerSecond, 1f);

            for (int i = 0; i < full.Length; i++)
            {
                ui.text = full.Substring(0, i + 1);
                yield return new WaitForSeconds(interval);
            }

            _typingCo = null;
            _waitingInput = true;
        }

        private void SkipTyping()
        {
            StoryLine line = _currentSequence.lines[_index];

            if (_typingCo != null)
            {
                StopCoroutine(_typingCo);
                _typingCo = null;
            }

            dialogueText.text = line.text;
            _waitingInput = true;
        }
        
        private void UpdateSpeaker(StoryLine line)
        {
            if (string.IsNullOrEmpty(line.speakerId))
            {
                speakerText.text = "";
                return;
            }

            var c = characterDatabase.GetCharacter(line.speakerId);
            speakerText.text = c != null ? c.displayName : line.speakerId;
        }

        private void UpdateCharacters(StoryLine line)
        {
            // 먼저 모두 비활성화 (기본 상태)
            leftCharacterImage.enabled = false;
            centerCharacterImage.enabled = false;
            rightCharacterImage.enabled = false;

            // 배경 컷 (position = None)
            if (line.position == "None" || string.IsNullOrEmpty(line.position) && (line.positions == null || line.positions.Length == 0))
                return;

            // 단일 캐릭터(old 방식, 호환성 유지)
            if (line.positions == null || line.positions.Length == 0)
            {
                var c = characterDatabase.GetCharacter(line.speakerId);
                Sprite sp = c != null ? c.GetExpressionSprite(line.expressionKey) : null;

                if (line.position == "Left")
                    SetCharacterWithFade(leftCharacterImage, sp);

                else if (line.position == "Center")
                    SetCharacterWithFade(centerCharacterImage, sp);

                else if (line.position == "Right")
                    SetCharacterWithFade(rightCharacterImage, sp);

                return;
            }

            // 복수 캐릭터 배열 처리
            foreach (var p in line.positions)
            {
                var charData = characterDatabase.GetCharacter(p.speakerId);
                Sprite sp = charData != null ? charData.GetExpressionSprite(p.expressionKey) : null;

                if (p.pos == "Left")
                    SetCharacterWithFade(leftCharacterImage, sp);

                else if (p.pos == "Center")
                    SetCharacterWithFade(centerCharacterImage, sp);

                else if (p.pos == "Right")
                    SetCharacterWithFade(rightCharacterImage, sp);
            }
        }

        private void UpdateBackground(StoryLine line)
        {
            if (string.IsNullOrEmpty(line.backgroundKey)) return;

            var bg = backgroundDatabaseSo.GetBackGround(line.backgroundKey);
            if (bg != null)
            {
                backgroundImage.sprite = bg;
                backgroundImage.enabled = true;
            }
        }

        private void SetCharacterWithFade(Image img, Sprite sp)
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

            img.enabled = true;
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
    }
}
