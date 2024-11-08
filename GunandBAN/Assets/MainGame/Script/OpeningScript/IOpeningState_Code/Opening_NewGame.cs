using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_NewGame : IOpening
{
    OpeningPlayer openingPlayer;

    public Opening_NewGame(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.NewGame;

    
    /// <summary>
    /// 
    /// </summary>
    void IOpening.Init()
    {
        openingPlayer.title.SetActive(true);
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
}
