using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITalkEvent
{
    void Init();
    /// <summary>
    /// �_���[�W�̃X�N���v�g�z��
    /// </summary>
    void Update();
    /// <summary>
    /// 1�ڂ̑I����
    /// </summary>
    void TrueEnd();
    /// <summary>
    /// 2�ڂ̑I����
    /// </summary>
    void FalseEnd();
}
