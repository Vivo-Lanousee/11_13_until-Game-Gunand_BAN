using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Streaming_GameScene�Ŏg��Interface
/// </summary>
public interface IMainGame
{
    public MainGameState Maingame { get;}
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// Enum�ŃQ�[�����̏���
/// </summary>
public enum MainGameState{
    InitTime,//�f�[�^�̃��[�h����
    Main,//�ʏ�̃Q�[��
    Main_early,//�����i���j
    Pose,//�|�[�Y
    DayEnd//�Q�[���̏I������
}
