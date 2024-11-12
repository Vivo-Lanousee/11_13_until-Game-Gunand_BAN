using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 今回別にそんなに重要じゃないと思うので仮置き。
/// </summary>
public class Opening_Option : IOpening
{
    private OpeningPlayer openingPlayer;

    public Opening_Option(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.Option;

    /// <summary>
    /// OpeningシーンへOnClick登録
    /// </summary>
    void IOpening.Init()
    {
        openingPlayer.title();
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
