using System;
using System.Collections;
using _00.Work.Lusalord._02.Script.VisualNovel;
using _00.Work.Lusalord._02.Script.VisualNovel.AttributeData;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextWriteUI : MonoBehaviour
{
    [SerializeField] private WritingController writingController;
    [SerializeField] private TextMeshProUGUI speakerText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    private bool _isTyping;
    
    private void Start()
    {
        ShowCurrentLine();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (_isTyping)
            {
                StopAllCoroutines();
                AttributeDataLine line = writingController?.GetCurrentLine();
                Debug.Assert(!writingController, "WritingController가 존재하지 않습니다.");
                if (line != null) 
                    dialogueText.text = line.text;
                _isTyping = false;
            }
            else
            {
                OnNextClicked();
            }
        }
    }

    private void OnNextClicked()
    {
        writingController.NextText();

        if (writingController.IsFinished())
        {
            speakerText.text = "";
            dialogueText.text = "대화가 끝났습니다.";
            return;
        }
    }
    private void ShowCurrentLine()
    {
        AttributeDataLine line = writingController.GetCurrentLine();

        if (line == null)
        {
            speakerText.text = "";
            dialogueText.text = "대화가 끝났습니다.";
            return;
        }

        speakerText.text = line.speaker;
        StopAllCoroutines();
        StartCoroutine(TypeEffect(line.text));
        
    }
    private IEnumerator TypeEffect(string lineText)
    {
        _isTyping = true;
        dialogueText.text = "";

        int i = 0;
        while (i < lineText.Length)
        {
            dialogueText.text += lineText[i];
            i++;
            yield return new WaitForSeconds(0.03f);
        }

        _isTyping = false;
    } 
}
