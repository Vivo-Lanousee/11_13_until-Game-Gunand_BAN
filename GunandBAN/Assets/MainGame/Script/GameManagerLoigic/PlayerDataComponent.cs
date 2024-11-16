using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// プレイヤーの重要データ
/// </summary>:
[Serializable]
public class PlayerDataComponent
{
    public string PlayerName;
    public string Chapter;
    public int Level;
    public int UserExp;
    /// <summary>
    /// SRPGのゲームの難易度の上限
    /// </summary>
    public int SRPGGameLevel;
}
