using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通常のゲーム時
/// </summary>
public class GameMain_Main : IMainGame
{
    GameMainPlayer _player;
    public MainGameState Maingame => MainGameState.Main;

    public GameMain_Main(GameMainPlayer player) { 
        _player = player;
    }

    void IMainGame.Init()
    {

    }
    void IMainGame.Exit()
    {
    }
    void IMainGame.Update()
    {
    }
    void IMainGame.FixUpdate()
    {
    }
}
