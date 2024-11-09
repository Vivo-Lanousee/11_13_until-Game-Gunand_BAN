using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;
using R3.Triggers;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// �V�����A�J�E���g�쐬���̏���
/// </summary>
public class Opening_NewMyAccount : IOpening
{
    private OpeningPlayer openingPlayer;
    //InputField�̍w�ǉ���
    IDisposable InputField_dispose;
    InputField tes;
    TMP_InputField tester;
    

    public Opening_NewMyAccount(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.NewMyAccount;

    /// <summary>
    /// Opening�V�[����OnClick�o�^
    /// </summary>
    void IOpening.Init()
    {
        openingPlayer.title.SetActive(true);
        openingPlayer.NewGame.SetActive(false);
        openingPlayer.Option.SetActive(false);

        NewGame_NewMyAccount_Component test=openingPlayer.NewMyAccount.GetComponent<NewGame_NewMyAccount_Component>();
        
       
    }
    void IOpening.Exit()
    {
        openingPlayer.title.SetActive(false);
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
