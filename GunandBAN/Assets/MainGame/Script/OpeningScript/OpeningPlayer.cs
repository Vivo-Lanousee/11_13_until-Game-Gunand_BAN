using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningPlayer : MonoBehaviour
{
    public GameObject title;
    public GameObject NewGame;
    public GameObject Option;
    public GameObject NewMyAccount;

    private OpeningContext OpeningContext;

    private void Awake()
    {
        OpeningContext = new OpeningContext();
        OpeningContext.Opening_Init(this, OpeningState.NewMyAccount);
    }

    private void Update() => OpeningContext.Opening_currentState.Update();
    private void FixedUpdate() => OpeningContext.Opening_currentState.FixUpdate();


}
/// <summary>
/// 対応するState
/// </summary>
public enum OpeningState
{
    Title,//初期状態
    Option,//設定状態
    NewGame,//ゲームデータ初期化画面
    NewMyAccount,//アカウント作成画面
}