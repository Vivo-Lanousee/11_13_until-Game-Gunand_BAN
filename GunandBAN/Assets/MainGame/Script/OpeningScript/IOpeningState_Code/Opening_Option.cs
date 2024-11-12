using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ʂɂ���Ȃɏd�v����Ȃ��Ǝv���̂ŉ��u���B
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
    /// Opening�V�[����OnClick�o�^
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
