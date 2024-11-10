using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningContext
{
    public IOpening Opening_currentState;
    public IOpening Opening_beforeState;

    public Dictionary<OpeningState, IOpening> StatePairTable;

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="player"></param>
    /// <param name="OpeningInit"></param>
    public void Opening_Init(OpeningPlayer player, OpeningState OpeningInit) 
    {
        Dictionary<OpeningState, IOpening> InitTable
        = new(){
                {OpeningState.Title, new Opening_Title(player)},
                {OpeningState.Option,new Opening_Option(player)},
                {OpeningState.NewGame,new Opening_NewGame(player)},
                {OpeningState.NewMyAccount,new Opening_NewMyAccount(player)},
                };
        StatePairTable = InitTable;

        //������
        Opening_ChangeState(OpeningInit);
    }

    /// <summary>
    /// ��ԑJ�ڂ����邽�߂̂���
    /// </summary>
    /// <param name="OpeningState"></param>
    public void Opening_ChangeState(OpeningState OpeningState)
    {
        Opening_beforeState = Opening_currentState;
        Opening_currentState=StatePairTable[OpeningState];

        Opening_beforeState?.Exit();
        Opening_currentState.Init();
    }
}
