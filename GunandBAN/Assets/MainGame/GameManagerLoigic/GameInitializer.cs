using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エントリーポイント
/// </summary>
public class GameInitializer : MonoBehaviour
{
    // 初期化処理
    public static bool IsInitialized { get; private set; } = false;

    //ゲーム開始時に実行される
    [RuntimeInitializeOnLoadMethod()]
    static void Initialize()
    {
        Debug.Log("ゲーム開始");
        //ゲーム開始
        GameManager.Instance();
        
    }
}
