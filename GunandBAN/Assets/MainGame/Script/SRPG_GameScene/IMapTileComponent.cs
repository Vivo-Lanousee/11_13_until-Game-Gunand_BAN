using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface IMapTileComponent
{
    /// <summary>
    /// �^�C���l�[��
    /// </summary>
    public string TileName { get;  }
    /// <summary>
    /// �ړ��R�X�g
    /// </summary>
     public int Cost { get;}
    
    //�ړ��s���ǂ���
    public bool IsLocked { get; }
    /// <summary>
    /// �����l�{�[�i�X
    /// </summary>
    int AC { get; }
    /// <summary>
    /// ���l�{�[�i�X
    /// </summary>
    int EV { get; }

    /// <summary>
    /// �o�t
    /// </summary>
    IBuff buff { get; }
}
public interface IBuff{
    public void init();
    public void end();

    public void Every();
}