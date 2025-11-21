using System;
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
        
        [Header("UI")] 
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image leftCharacterImage;
        [SerializeField] private Image centerCharacterImage;
        [SerializeField] private Image rightCharacterImage;

        [SerializeField] private TextMeshProUGUI speakerText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        
        [Header("선택지 UI")]
        [SerializeField] private GameObject choicePanel;
        [SerializeField] private Button choiceButtonPrefab;

        private StorySequenceList _storyData;
        private StorySequenceList _storySequenceList;
        private StorySequence _currentSequence;

        private int _index;
        public bool _waiting;
        private bool _inChoice;

        private Dictionary<string, StorySequence> _seqMap;
        private void Start()
        {
            LoadStory();

            StartSequence("Intro");
        }
        
        private void Update()
        {
            if (_inChoice)
                return;

            if (!_waiting && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                ShowNext();
            }
        }
        
        private void LoadStory()
        {
            _storyData = StoryJsonLoader.Load(storyAsset);
            
            Debug.Assert(_storyData != null, "스토리 데이터를 불러올 수 없습니다.");

            _seqMap = new Dictionary<string, StorySequence>();
            foreach (var seq in _storyData.sequences)
                _seqMap[seq.sequenceId] = seq;
        }

        private void StartSequence(string seqId)
        {
            Debug.Assert(_seqMap.TryGetValue(seqId, out _currentSequence), 
                "시퀀스를 찾을 수 없습니다: " + seqId);
            
            _index = -1;
            ShowNext();
        }

        private void ShowNext()
        {
            _index++;
            if (_index >= _currentSequence.lines.Count)
            {
                Debug.Log("시퀀스 종료");
                return;
            }
            var line = _currentSequence.lines[_index];
            
            UpdateSpeaker(line);
            UpdateCharacters(line);
            UpdateBackground(line);
            dialogueText.text = line.text;
        }
        private void ShowChoices(StoryLineData[] choices)
    {
        _waiting = false;
        _inChoice = true;

        choicePanel.SetActive(true);

        // 기존 버튼 삭제
        foreach (Transform child in choicePanel.transform)
            Destroy(child.gameObject);

        // 버튼 생성
        foreach (var choice in choices)
        {
            var btn = Instantiate(choiceButtonPrefab, choicePanel.transform);
            btn.GetComponentInChildren<TMP_Text>().text = choice.choiceText;

            string nextId = choice.nextSequence;

            btn.onClick.AddListener(() =>
            {
                choicePanel.SetActive(false);
                _inChoice = false;
                StartSequence(nextId);
            });
        }
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
            var c = characterDatabase.GetCharacter(line.speakerId);
            Sprite sp = c != null ? c.GetExpressionSprite(line.expressionKey) : null;

            if (line.hideOthers)
            {
                leftCharacterImage.enabled = false;
                centerCharacterImage.enabled = false;
                rightCharacterImage.enabled = false;
            }

            if (line.position == "Left")
                SetImg(leftCharacterImage, sp);
            else if (line.position == "Center")
                SetImg(centerCharacterImage, sp);
            else if (line.position == "Right")
                SetImg(rightCharacterImage, sp);
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

        private void SetImg(Image img, Sprite s)
        {
            img.sprite = s;
            img.enabled = s != null;
        }
    }
}