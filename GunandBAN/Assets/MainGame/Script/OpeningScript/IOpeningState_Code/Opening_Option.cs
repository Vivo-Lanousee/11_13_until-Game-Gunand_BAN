using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Option : IOpening
{
    private OpeningPlayer openingPlayer;

    public Opening_Option(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.Option;

    /// <summary>
    /// OpeningÉVÅ[ÉìÇ÷OnClickìoò^
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
