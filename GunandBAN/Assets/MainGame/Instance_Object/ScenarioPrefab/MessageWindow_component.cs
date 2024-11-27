using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageWindow_component : MonoBehaviour
{
    /// <summary>
    /// �I������UI
    /// </summary>
    public GameObject TrueFalse;

    /// <summary>
    /// True�I����UI
    /// </summary>
    public Button True;
    public TextMeshProUGUI truetext;

    /// <summary>
    /// False�I����UI
    /// </summary>
    public Button False;
    public TextMeshProUGUI falsetext;

    /// <summary>
    /// �\�����́B
    /// </summary>
    public TextMeshProUGUI Message;

    /// <summary>
    /// �e�L�X�g
    /// </summary>
    /// <param name="true_text"></param>
    /// <param name="false_text"></param>
    public void TextExChange(string true_text,string false_text)
    {
        truetext.text = true_text;
        falsetext.text = false_text;
    }
    /// <summary>
    /// TrueFalse�̃{�^�����K�v�Ȃ��Ƃ��̏���
    /// </summary>
    public void TrueFalse_Off()
    {
        TrueFalse.SetActive(false);
    }

    public void MessageTextChange(string text)
    {
        Message.text=text;
    }
}
