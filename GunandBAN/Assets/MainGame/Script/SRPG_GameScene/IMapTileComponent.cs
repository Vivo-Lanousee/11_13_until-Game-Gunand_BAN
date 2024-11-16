using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface IMapTileComponent
{
    /// <summary>
    /// タイルネーム
    /// </summary>
    public string TileName { get;  }
    /// <summary>
    /// 移動コスト
    /// </summary>
     public int Cost { get;}
    
    //移動不可かどうか
    public bool IsLocked { get; }
    /// <summary>
    /// 命中値ボーナス
    /// </summary>
    int AC { get; }
    /// <summary>
    /// 回避値ボーナス
    /// </summary>
    int EV { get; }

    /// <summary>
    /// バフ
    /// </summary>
    IBuff buff { get; }
}
public interface IBuff{
    public void init();
    public void end();

    public void Every();
}