using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�X�g�p�̃X�N���v�g
/// </summary>
public class Can : MonoBehaviour
{
    public GameObject canvas;
    PopUpWindowManage popUpWindow;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializePopUpWindow());
    }

    IEnumerator InitializePopUpWindow()
    {
        // PopUpWindowManage���C���X�^���X�����ă|�b�v�A�b�v��\������
        popUpWindow = PopUpWindowManage.Instance();

        // �񓯊��Ń|�b�v�A�b�v�E�B���h�E��\��
        popUpWindow.PopUp_Window_Instante("�J���`���b�J�t�@�C�A�[�I�I�I", this.gameObject);

        // �񓯊���������������܂őҋ@����
        yield return new WaitForSeconds(0.1f);  

        // �|�b�v�A�b�v������ɐݒ肳��Ă���΁A�{�^����\��
        if (popUpWindow.popupwindow != null)
        {
            Debug.Log(popUpWindow.popupwindow.button);
            //popUpWindow.popupwindow.button.onClick.RemoveAllListeners();
        }
    }
}