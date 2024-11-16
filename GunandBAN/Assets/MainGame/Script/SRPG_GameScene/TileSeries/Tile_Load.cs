using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Load : MonoBehaviour, IMapTileComponent
{
    /// <summary>
    /// キャラクター⇒最初から参照せず、逐次参照する
    /// </summary>
    public Srpg_player Character;

    IBuff buff;

    int IMapTileComponent.Cost => 1;

    bool IMapTileComponent.IsLocked => false;
    public string TileName => "Load";
    int IMapTileComponent.AC => 20;
    int IMapTileComponent.EV => 10;

    IBuff IMapTileComponent.buff { get; }
}
