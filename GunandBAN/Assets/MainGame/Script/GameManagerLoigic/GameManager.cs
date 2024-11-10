using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// データの管理。ゲームのロジックは書かずにゲームのデータ管理だけを行い、尚且つ
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// データの初期化処理と登録処理実行
    /// </summary>
   public void UserDataInit()
    {
        Addressables.LoadAssetAsync<TextAsset>("").Completed += _ => 
        { 
        
        };
    }
}
