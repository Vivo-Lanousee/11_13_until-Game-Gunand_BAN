using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC、『UserList』のデータ保管。
/// </summary>

[Serializable]
public class UserData
{
    //プライマリーキーとしての役割    
    public int Id;

    public string UserName;
    /// <summary>
    /// 敵かどうかを示す値。0~100の範囲。
    /// 「0~30は悪」「31~70は中立」「71~100は善」→想定
    /// </summary>
    public int Caluma;

    /// <summary>
    /// コメント履歴
    /// </summary>
    public List<string> Comment_Log_List;

    /// <summary>
    /// BANする時の判定
    /// </summary>
    public bool BAN_onoff;
}
