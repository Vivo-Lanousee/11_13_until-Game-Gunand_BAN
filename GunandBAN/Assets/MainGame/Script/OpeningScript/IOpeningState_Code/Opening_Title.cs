using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening_Title : IOpening
{
    OpeningPlayer openingPlayer;
    Opening_Title(OpeningPlayer player)
    {
        openingPlayer = player;
}

    OpeningState IOpening.Opening => OpeningState.Title;

    /// <summary>
    /// Opening�V�[����OnClick�o�^
    /// </summary>
    void IOpening.Init()
    {

    }
    void IOpening.Exit()
    {
    }

    void IOpening.FixUpdate()
    {
    }


    void IOpening.Update()
    {
    }
}
