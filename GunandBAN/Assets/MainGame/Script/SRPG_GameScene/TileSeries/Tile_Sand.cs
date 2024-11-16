using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̃}�b�v�f�[�^�B������ł��ׂĒ��g���L�ڂ��Ă���B
/// ������A�L�����N�^�[���f�[�^��K�v�ɂȂ����Ƃ��Ɏ擾���邽�߂ɃC���^�[�t�F�[�X���g�p���Ă���
/// </summary>
public class Tile_Sand : MonoBehaviour, IMapTileComponent
{
    /// <summary>
    /// �L�����N�^�[�ˍŏ�����Q�Ƃ����A�����Q�Ƃ���
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