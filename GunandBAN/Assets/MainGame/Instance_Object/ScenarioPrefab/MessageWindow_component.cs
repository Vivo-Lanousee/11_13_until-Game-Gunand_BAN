using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageWindow_component : MonoBehaviour
{
    public GameObject TrueFalse;
    public Button True;
    public TextMeshProUGUI truetext;

    public Button False;
    public TextMeshProUGUI falsetext;
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
}
