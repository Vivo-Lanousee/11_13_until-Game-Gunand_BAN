using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MessageWindow_component : MonoBehaviour
{
    public GameObject TrueFalse;
    public Button True;
    public Button False;
    public TextMeshProUGUI Message;

    /// <summary>
    /// TrueFalse�̃{�^�����K�v�Ȃ��Ƃ��̏���
    /// </summary>
    public void TrueFalse_Off()
    {
        TrueFalse.SetActive(false);
    }
}
