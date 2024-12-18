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
    /// <param name_list="player"></param>
    /// <param name_list="OpeningInit"></param>
    public void Opening_Init(OpeningPlayer player, OpeningState OpeningInit) 
    {
        Dictionary<OpeningState, IOpening> InitTable
        = new(){
                {OpeningState.Title, new Opening_Title(player)},
                {OpeningState.Option,new Opening_Option(player)},
                {OpeningState.NewGamePopUp,new Opening_NewGamePopUp(player)},
                {OpeningState.NewMyAccount,new Opening_NewMyAccount(player)},
                };
        StatePairTable = InitTable;

        //初期化
        Opening_ChangeState(OpeningInit);
    }

    /// <summary>
    /// 状態遷移させるためのもの
    /// </summary>
    /// <param name_list="OpeningState"></param>
    public void Opening_ChangeState(OpeningState OpeningState)
    {
        Opening_beforeState = Opening_currentState;
        Opening_currentState=StatePairTable[OpeningState];

        Opening_beforeState?.Exit();
        Opening_currentState.Init();
    }
}
