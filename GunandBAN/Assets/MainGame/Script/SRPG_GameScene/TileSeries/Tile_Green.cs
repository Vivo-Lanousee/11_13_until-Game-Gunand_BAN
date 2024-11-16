using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 草原のマップデータ。こちらですべて中身を記載している。
/// </summary>
public class Tile_Green : MonoBehaviour, IMapTileComponent
{ 
    /// <summary>
    /// キャラクター⇒最初から参照せず、逐次参照する
    /// </summary>
    public Srpg_player Character;

    IBuff buff;

    int IMapTileComponent.Cost => 1;

    bool IMapTileComponent.IsLocked => false;
    public string TileName =>"Green";
    int IMapTileComponent.AC=>0;
    int IMapTileComponent.EV =>0;

    IBuff IMapTileComponent.buff { get; }
}
