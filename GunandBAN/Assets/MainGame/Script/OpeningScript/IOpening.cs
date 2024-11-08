using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OpeningScene�ł�
/// </summary>
public interface IOpening
{
    public OpeningState Opening { get; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}

/// <summary>
/// �Ή�����State
/// </summary>
public enum OpeningState
{
    Title,//�������
    Option,//�ݒ���
    NewGame,//
}