using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ITalkEvent
{
    void Init();
    /// <summary>
    /// ダメージのスクリプト想定
    /// </summary>
    void Update();
    /// <summary>
    /// 1個目の選択肢
    /// </summary>
    void TrueEnd();
    /// <summary>
    /// 2個目の選択肢
    /// </summary>
    void FalseEnd();
}
