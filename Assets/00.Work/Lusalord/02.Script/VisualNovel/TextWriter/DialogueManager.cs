using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _00.Work.Lusalord._02.Script.VisualNovel.TextWriter
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private DialogueSO dialogueSo;
        [SerializeField] private TMP_Text speakerText;
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private float typingSpeed = 0.03f; // 글자 출력 속도 (초)

        private int _index;
        private bool _isTyping;

        private void OnValidate()
        {
            dialogueSo.LoadFromJson(); 
            
        }

        private void Start()
        {
            ShowDialogue();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                if (_isTyping)
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueSo.dialogues[_index].text;
                    _isTyping = false;
                }
                else
                {
                    NextDialogue();
                }
            }
        }

        private void ShowDialogue()
        {
            if (_index >= dialogueSo.dialogues.Length)
            {
                speakerText.text = "";
                dialogueText.text = "";
                Debug.Log("모든 대화가 끝났습니다.");
                return;
            }

            var data = dialogueSo.dialogues[_index];
            speakerText.text = data.speaker;
            StartCoroutine(TypeText(data.text));
        }

        private IEnumerator TypeText(string line)
        {
            _isTyping = true;
            dialogueText.text = "";

            // 안전하게 모든 글자 출력
            for (int i = 0; i < line.Length; i++)
            {
                dialogueText.text += line[i];
                yield return new WaitForSeconds(typingSpeed);
            }

            _isTyping = false;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void NextDialogue()
        {
            _index++;
            ShowDialogue();
        }
    }
}
