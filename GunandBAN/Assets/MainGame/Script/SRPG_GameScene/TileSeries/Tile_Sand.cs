using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 砂のマップデータ。こちらですべて中身を記載している。
/// 生成後、キャラクターがデータを必要になったときに取得するためにインターフェースを使用している
/// </summary>
public class Tile_Sand : MonoBehaviour, IMapTileComponent
{
    /// <summary>
    /// キャラクター⇒最初から参照せず、逐次参照する
    /// </summary>
    public Srpg_player Character;

    IBuff buff;
    
    int IMapTileComponent.Cost => 3;

    bool IMapTileComponent.IsLocked => false;
    public string TileName => "Sand";
    int IMapTileComponent.AC => 0;
    int IMapTileComponent.EV => 0;

    IBuff IMapTileComponent.buff { get; }
}