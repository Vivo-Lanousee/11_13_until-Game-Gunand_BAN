using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain_Pose : IMainGame
{
    GameMainPlayer _player;
    public MainGameState Maingame => MainGameState.Pose;

    public GameMain_Pose(GameMainPlayer player)
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
