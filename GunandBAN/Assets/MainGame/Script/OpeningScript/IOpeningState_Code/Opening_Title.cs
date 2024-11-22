using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening_Title : IOpening
{
    private OpeningPlayer openingPlayer;
    
    public Opening_Title(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.Title;

    /// <summary>
    /// Opening�V�[����OnClick�o�^
    /// </summary>
    void IOpening.Init()
    {
        OnClickEventInput();
        AllButtonOff();
        AllButtonOn();

        openingPlayer.Title.SetActive(true);
        openingPlayer.NewGamePopUp.SetActive(false);
        openingPlayer.Option.SetActive(false);
        openingPlayer.NewGamePopUp.SetActive(false);
    }
    void IOpening.Exit()
    {
        openingPlayer.Title.SetActive(false);
        AllButtonOff();
    }

    void IOpening.FixUpdate()
    {
    }

    void IOpening.Update()
    {
    }

    public void OnClickEventInput()
    {
        Title_Component title=openingPlayer.Title.GetComponent<Title_Component>();

        //OnClick����
        title.Continue_button.onClick.RemoveAllListeners();
        title.NewGame_button.onClick.RemoveAllListeners();
        title.Option_button.onClick.RemoveAllListeners();
        title.Credit_button.onClick.RemoveAllListeners();

        Debug.Log("test");
        //�C�x���g�t��

        //�R���e�B�j���[
        title.Continue_button.onClick.AddListener(() => {
            SceneManager.LoadScene("Lobby_Scene");
        });
        //�j���[�Q�[��
        title.NewGame_button.onClick.AddListener(() => { openingPlayer.newgame_popup(); });
        title.Option_button.onClick.AddListener(() => { openingPlayer.option(); });
        title.Credit_button.onClick.AddListener(() => { });
    }

    private void AllButtonOn()
    {
        Title_Component title = openingPlayer.Title.GetComponent<Title_Component>();
        
        GameManager gameManager=GameManager.Instance();
        gameManager.PlayerDataDownLoad();
        if (gameManager.Player.PlayerName!="") {
            title.Continue_button.interactable = true;
        }
        title.NewGame_button.interactable = true;
        title.Option_button.interactable = true;
        title.Credit_button.interactable = true;
    }
    private void AllButtonOff()
    {
        Title_Component title = openingPlayer.Title.GetComponent<Title_Component>();

        title.Continue_button.interactable = false;
        title.NewGame_button.interactable = false;
        title.Option_button.interactable = false;
        title.Credit_button.interactable=false;
    }
}