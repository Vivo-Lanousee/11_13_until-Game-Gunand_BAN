using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OpeningScene‚Å‚Ì
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
/// ‘Î‰‚·‚éState
/// </summary>
public enum OpeningState
{
    Title,//‰Šúó‘Ô
    Option,//İ’èó‘Ô
    NewGame,//
}