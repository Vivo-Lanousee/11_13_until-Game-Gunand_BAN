using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ’Êí‚ÌƒQ[ƒ€
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
