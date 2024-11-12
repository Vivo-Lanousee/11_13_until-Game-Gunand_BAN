using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningPlayer : MonoBehaviour
{
    public GameObject Title;
    public GameObject NewGamePopUp;
    public GameObject Option;
    public GameObject NewMyAccount;

    private OpeningContext OpeningContext;

    private void Awake()
    {
        OpeningContext = new OpeningContext();
        OpeningContext.Opening_Init(this, OpeningState.Title);
    }

    //private void Update() => OpeningContext.Opening_currentState.Update();
    //private void FixedUpdate() => OpeningContext.Opening_currentState.FixUpdate();


    public void title() => OpeningContext.Opening_ChangeState(OpeningState.Title);
    public void option() => OpeningContext.Opening_ChangeState(OpeningState.Option);
    public void newgame_popup() => OpeningContext.Opening_ChangeState(OpeningState.NewGamePopUp);
    public void newmyaccount() => OpeningContext.Opening_ChangeState(OpeningState.NewMyAccount);


}
/// <summary>
/// 対応するState
/// </summary>
public enum OpeningState
{
    Title,//初期状態
    Option,//設定状態
    NewGamePopUp,//ゲームデータ初期化画面
    NewMyAccount,//アカウント作成画面
}