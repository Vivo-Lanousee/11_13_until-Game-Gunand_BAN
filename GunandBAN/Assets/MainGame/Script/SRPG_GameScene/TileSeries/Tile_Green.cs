using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����̃}�b�v�f�[�^�B������ł��ׂĒ��g���L�ڂ��Ă���B
/// </summary>
public class Tile_Green : MonoBehaviour, IMapTileComponent
{ 
    /// <summary>
    /// �L�����N�^�[�ˍŏ�����Q�Ƃ����A�����Q�Ƃ���
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
