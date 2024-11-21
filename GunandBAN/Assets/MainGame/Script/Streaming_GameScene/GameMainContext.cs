using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainContext
{
    public IMainGame MainGame_currentState;
    public IMainGame MainGame_beforeState;

    public Dictionary<MainGameState, IMainGame> StatePairTable;

    /// <summary>
    /// ������
    /// </summary>
    /// <param name_list="player"></param>
    /// <param name_list="MainInit"></param>
    public void MainGame_Init(GameMainPlayer player,MainGameState MainInit) 
    {

        Dictionary<MainGameState, IMainGame> InitTable
        = new(){
                { MainGameState.Main, new GameMain_Main(player)},
                { MainGameState.InitTime,new GameMain_InitTime(player)},
                {MainGameState.Pose,new GameMain_Pose(player)},
                };
        StatePairTable = InitTable;

        //������
        MainGame_ChangeState(MainInit);
    }

    /// <summary>
    /// ��ԑJ�ڂ����邽�߂̂���
    /// </summary>
    /// <param name_list="mainGameState"></param>
    public void MainGame_ChangeState(MainGameState mainGameState)
    {
        MainGame_beforeState = MainGame_currentState;
        MainGame_currentState=StatePairTable[mainGameState];

        MainGame_beforeState?.Exit();
        MainGame_currentState.Init();
    }
}
