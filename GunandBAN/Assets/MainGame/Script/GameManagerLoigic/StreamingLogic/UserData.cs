using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC�A�wUserList�x�̃f�[�^�ۊǁB
/// </summary>

[Serializable]
public class UserData
{
    //�v���C�}���[�L�[�Ƃ��Ă̖���    
    public int Id;

    public string UserName;
    /// <summary>
    /// �G���ǂ����������l�B0~100�͈̔́B
    /// �u0~30�͈��v�u31~70�͒����v�u71~100�͑P�v���z��
    /// </summary>
    public int Caluma;

    /// <summary>
    /// �R�����g����
    /// </summary>
    public List<string> Comment_Log_List;

    /// <summary>
    /// BAN���鎞�̔���
    /// </summary>
    public bool BAN_onoff;
}
