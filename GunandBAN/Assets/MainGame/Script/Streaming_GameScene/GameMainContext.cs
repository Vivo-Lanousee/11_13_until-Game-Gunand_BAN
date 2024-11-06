using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainContext
{
    public IMainGame MainGame_currentState;
    public IMainGame MainGame_beforeState;

    public Dictionary<MainGameState, IMainGame> StatePairTable;
    public void Init(GameMainPlayer player) 
    {
        Dictionary<MainGameState, IMainGame> InitTable
        = new(){
                { MainGameState.Main, new GameMain_Main(player)}

                };
        StatePairTable = InitTable;



    }

    /// <summary>
    /// èÛë‘ëJà⁄Ç≥ÇπÇÈÇΩÇﬂÇÃÇ‡ÇÃ
    /// </summary>
    /// <param name="mainGameState"></param>
    public void ChangeState(MainGameState mainGameState)
    {
        MainGame_beforeState = MainGame_currentState;
        MainGame_currentState=StatePairTable[mainGameState];
    }
}
