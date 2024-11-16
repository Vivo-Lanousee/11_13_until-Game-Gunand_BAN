using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Load : MonoBehaviour, IMapTileComponent
{
    /// <summary>
    /// �L�����N�^�[�ˍŏ�����Q�Ƃ����A�����Q�Ƃ���
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
