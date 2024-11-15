using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Green : MonoBehaviour, IMapTileComponent
{ 
    /// <summary>
    /// キャラクター
    /// </summary>
    public Srpg_player player;

    IBuff buff;

    int IMapTileComponent.Cost => 1;

    public string TileName =>"Green";
    int IMapTileComponent.AC=>0;
    int IMapTileComponent.EV =>0;

    IBuff IMapTileComponent.buff { get; }
}
