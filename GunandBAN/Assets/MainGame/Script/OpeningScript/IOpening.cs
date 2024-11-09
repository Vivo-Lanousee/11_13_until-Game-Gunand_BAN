using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OpeningSceneでの
/// </summary>
public interface IOpening
{
    public OpeningState Opening { get; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// 対応するState
/// </summary>
public enum OpeningState
{
    Title,//初期状態
    Option,//設定状態
    NewGame,//
    NewMyAccount,//アカウント作成画面
}