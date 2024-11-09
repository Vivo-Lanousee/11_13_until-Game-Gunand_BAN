using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningContext
{
    public IOpening Opening_currentState;
    public IOpening Opening_beforeState;

    public Dictionary<OpeningState, IOpening> StatePairTable;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="player"></param>
    /// <param name="MainInit"></param>
    public void MainGame_Init(OpeningPlayer player, OpeningState MainInit) 
    {
        Dictionary<OpeningState, IOpening> InitTable
        = new(){
                {OpeningState.Title, new Opening_Title(player)},
                {OpeningState.Option,new Opening_Option(player)},
                {OpeningState.NewGame,new Opening_NewGame(player)},
                {OpeningState.NewMyAccount,new Opening_NewMyAccount(player)},
                };
        StatePairTable = InitTable;

        //初期化
        Opening_ChangeState(MainInit);
    }

    /// <summary>
    /// 状態遷移させるためのもの
    /// </summary>
    /// <param name="mainGameState"></param>
    public void Opening_ChangeState(OpeningState mainGameState)
    {
        Opening_beforeState = Opening_currentState;
        Opening_currentState=StatePairTable[mainGameState];

        Opening_beforeState?.Exit();
        Opening_currentState.Init();
    }
}
