using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_NoEntryField : MonoBehaviour, IMapTileComponent
{
    /// <summary>
    /// キャラクター⇒最初から参照せず、逐次参照する
    /// </summary>
    public Srpg_player Character;

    IBuff buff;

    int IMapTileComponent.Cost => 100;

    bool IMapTileComponent.IsLocked => true;
    public string TileName => "NoEntry";
    int IMapTileComponent.AC => -30;
    int IMapTileComponent.EV => -30;

    IBuff IMapTileComponent.buff { get; }
}