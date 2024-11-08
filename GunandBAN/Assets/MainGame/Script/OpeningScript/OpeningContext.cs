using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningContext
{
    public IOpening OpeningGame_currentState;
    public IOpening OpeningGame_beforeState;

    public Dictionary<OpeningState, IOpening> StatePairTable;

    /// <summary>
    /// ������
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
                };
        StatePairTable = InitTable;

        //������
        Opening_ChangeState(MainInit);
    }

    /// <summary>
    /// ��ԑJ�ڂ����邽�߂̂���
    /// </summary>
    /// <param name="mainGameState"></param>
    public void Opening_ChangeState(OpeningState mainGameState)
    {
        OpeningGame_beforeState = OpeningGame_currentState;
        OpeningGame_currentState=StatePairTable[mainGameState];

        OpeningGame_beforeState?.Exit();
        OpeningGame_currentState.Init();
    }
}
