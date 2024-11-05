using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム中のinterface_ゲームの状態遷移はStateパターンで作成
/// </summary>
public interface IGameMain 
{
    public MainGameState maingame { get; set; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// Enumでゲーム中の処理
/// </summary>
public enum MainGameState{
    Main,
    Main_second,
    Pose,
    DayEnd
}
