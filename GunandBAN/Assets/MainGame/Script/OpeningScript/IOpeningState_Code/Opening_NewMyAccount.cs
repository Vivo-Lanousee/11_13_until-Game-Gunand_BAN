using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using R3;
using R3.Triggers;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

/// <summary>
/// 新しいアカウント作成時の処理
/// </summary>
public class Opening_NewMyAccount : IOpening
{
    private OpeningPlayer openingPlayer;
    //InputFieldの購読解除
    IDisposable InputField_dispose;


    public Opening_NewMyAccount(OpeningPlayer player)
    {
        openingPlayer = player;
    }

    OpeningState IOpening.Opening => OpeningState.NewMyAccount;

    void IOpening.Init()
    {
        #region UI表示非表示処理
        openingPlayer.title.SetActive(false);
        openingPlayer.NewGame.SetActive(false);
        openingPlayer.Option.SetActive(false);
        openingPlayer.NewMyAccount.SetActive(true);
        #endregion

        //ポップアップ作成
        PopUpWindowManage pop =PopUpWindowManage.Instance();
        pop.PopUp_Window_Instante("データが初期化されました。",openingPlayer.NewMyAccount);

        //NewMyAccountにアタッチされているスクリプトから子オブジェクトを参照するため。
        NewGame_NewMyAccount_Component _newMyAccount_component=openingPlayer.NewMyAccount.GetComponent<NewGame_NewMyAccount_Component>();



        //Addressableで名前禁止リストダウンロード。その後名前入力欄に
        Addressables.LoadAssetAsync<TextAsset>("BlockUseName_WatchWarnigList").Completed += _ =>
        {
            if (_.Result == null)
            {
                return;
            }

            string str = _.Result.ToString();

            //これ以降使用しないので即リリース
            Addressables.Release(_);

            JObject list = JObject.Parse(str);
            string[] s = list["BlockName"].ToObject<string[]>();


            _newMyAccount_component.Error_Message.text = "新しいユーザー名を入力してください";
            _newMyAccount_component.DesicionButton.interactable = false;
            //ユーザー名入力のエラーメッセージの制御
            _newMyAccount_component.Name_inputField.onValueChanged.AddListener(_ =>
            {
                if (s.Contains(_))
                {
                    _newMyAccount_component.Error_Message.text = "エラー:この名前はユーザー名にできません";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else if (_ == "")
                {
                    _newMyAccount_component.Error_Message.text = "何も入力されていません";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else if (_.Length >= 14)
                {

                    _newMyAccount_component.Error_Message.text = "文字数が多すぎます！";
                    _newMyAccount_component.DesicionButton.interactable = false;
                }
                else
                {
                    _newMyAccount_component.Error_Message.text = "";
                    _newMyAccount_component.DesicionButton.interactable = true;
                }
            });

            //ボタンにユーザー名登録処理と初期化処理(Singletonで作成）と次のシーンへの変更処理を登録する
            _newMyAccount_component.DesicionButton.onClick.AddListener(() =>{ 
                pop.PopUp_Window_optionSelect_Instance(() => {
                    GameManager init = GameManager.Instance();
                    init.UserDataInit();
                    Debug.Log("test2");
                },
                "本当によろしいですか？",openingPlayer.NewMyAccount);
            });
            
        };
    }
    void IOpening.Exit()
    {
        //NewMyAccountにアタッチされているスクリプトから子オブジェクトを参照するため。
        NewGame_NewMyAccount_Component _newMyAccount_component = openingPlayer.NewMyAccount.GetComponent<NewGame_NewMyAccount_Component>();
        _newMyAccount_component.Name_inputField.onValueChanged.RemoveAllListeners();
    }

    void IOpening.FixUpdate()
    {
    }
    void IOpening.Update()
    {
    }

    public void OnClickEventInput()
    {

    }


}
