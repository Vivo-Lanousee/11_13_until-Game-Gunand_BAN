using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;
using R3.Triggers;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

/// <summary>
/// �V�����A�J�E���g�쐬���̏���
/// </summary>
public class Opening_NewMyAccount : IOpening
{
    private OpeningPlayer openingPlayer;
    //InputField�̍w�ǉ���
    IDisposable InputField_dispose;


    public Opening_NewMyAccount(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.NewMyAccount;

    void IOpening.Init()
    {
        #region UI�\����\������
        openingPlayer.title.SetActive(false);
        openingPlayer.NewGame.SetActive(false);
        openingPlayer.Option.SetActive(false);
        openingPlayer.NewMyAccount.SetActive(true);
        #endregion

        //�|�b�v�A�b�v�쐬
        PopUpWindowManage pop =PopUpWindowManage.Instance();
        pop.PopUp_Window_Instante("�f�[�^������������܂����B",openingPlayer.NewMyAccount);

        //NewMyAccount�ɃA�^�b�`����Ă���X�N���v�g����q�I�u�W�F�N�g���Q�Ƃ��邽�߁B
        NewGame_NewMyAccount_Component _newMyAccount_component=openingPlayer.NewMyAccount.GetComponent<NewGame_NewMyAccount_Component>();



        //Addressable�Ŗ��O�֎~���X�g�_�E�����[�h�B���̌㖼�O���͗���
        Addressables.LoadAssetAsync<TextAsset>("BlockUseName_WatchWarnigList").Completed += _ =>
        {
            if (_.Result == null)
            {
                return;
            }

            string str = _.Result.ToString();

            //����ȍ~�g�p���Ȃ��̂ő������[�X
            Addressables.Release(_);

            JObject list = JObject.Parse(str);
            string[] s = list["BlockName"].ToObject<string[]>();


            _newMyAccount_component.Error_Message.text = "�V�������[�U�[������͂��Ă�������";
            _newMyAccount_component.DesicionButton.interactable = false;
            //���[�U�[�����͂̃G���[���b�Z�[�W�̐���
            _newMyAccount_component.Name_inputField.onValueChanged.AddListener(_ =>
            {
                if (s.Contains(_))
                {
                    _newMyAccount_component.Error_Message.text = "�G���[:���̖��O�̓��[�U�[���ɂł��܂���";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else if (_ == "")
                {
                    _newMyAccount_component.Error_Message.text = "�������͂���Ă��܂���";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else if (_.Length >= 14)
                {

                    _newMyAccount_component.Error_Message.text = "���������������܂��I";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else
                {
                    _newMyAccount_component.Error_Message.text = "";
                    _newMyAccount_component.DesicionButton.interactable = true;
                }
            });

            //�{�^���Ƀ��[�U�[���o�^�����Ə���������(Singleton�ō쐬�j�Ǝ��̃V�[���ւ̕ύX������o�^����
            _newMyAccount_component.DesicionButton.onClick.AddListener(() =>{ 
                pop.PopUp_Window_optionSelect_Instance(() => {
                    GameManager init = GameManager.Instance();
                    init.UserDataInit();
                    Debug.Log("test2");
                },
                "�{���ɂ�낵���ł����H",openingPlayer.NewMyAccount);
            });
            
        };
    }
    void IOpening.Exit()
    {
        //NewMyAccount�ɃA�^�b�`����Ă���X�N���v�g����q�I�u�W�F�N�g���Q�Ƃ��邽�߁B
        NewGame_NewMyAccount_Component _newMyAccount_component = openingPlayer.NewMyAccount.GetComponent<NewGame_NewMyAccount_Component>();
        _newMyAccount_component.Name_inputField.onValueChanged.RemoveAllListeners();
    }

    void IOpening.FixUpdate()
    {
    }
    void IOpening.Update()
    {
    }

    public void OnClickEventInput()
    {

    }


}
