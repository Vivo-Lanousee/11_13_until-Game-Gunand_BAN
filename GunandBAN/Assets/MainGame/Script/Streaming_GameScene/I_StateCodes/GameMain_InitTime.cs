using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain_InitTime : IMainGame
{
    GameMainPlayer _player;
    public MainGameState Maingame => MainGameState.InitTime;

    public GameMain_InitTime(GameMainPlayer player)
    {
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
