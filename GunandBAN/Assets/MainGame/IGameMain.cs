using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[������interface_�Q�[���̏�ԑJ�ڂ�State�p�^�[���ō쐬
/// </summary>
public interface IGameMain 
{
    public MainGameState maingame { get; set; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// Enum�ŃQ�[�����̏���
/// </summary>
public enum MainGameState{
    Main,
    Main_second,
    Pose,
    DayEnd
}
