using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        openingPlayer.title.SetActive(true);
        openingPlayer.NewGame.SetActive(false);
        openingPlayer.Option.SetActive(false);
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