using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �v���C���[�̏d�v�f�[�^
/// </summary>:
[Serializable]
public class PlayerDataComponent
{
    public string PlayerName;
    public string Chapter;
    public int Level;
    public int UserExp;
    /// <summary>
    /// SRPG�̃Q�[���̓�Փx�̏��
    /// </summary>
    public int SRPGGameLevel;
}
