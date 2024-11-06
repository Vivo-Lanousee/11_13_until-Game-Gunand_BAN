using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Streaming_GameSceneで使うInterface
/// </summary>
public interface IMainGame
{
    public MainGameState Maingame { get;}
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// Enumでゲーム中の処理
/// </summary>
public enum MainGameState{
    InitTime,//データのロード時間
    Main,//通常のゲーム
    Main_early,//加速（仮）
    Pose,//ポーズ
    DayEnd//ゲームの終了処理
}
