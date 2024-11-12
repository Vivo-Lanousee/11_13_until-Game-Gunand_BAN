using System;
using R3;


public class Opening_NewGamePopUp : IOpening
{
    OpeningPlayer openingPlayer;
    public Opening_NewGamePopUp(OpeningPlayer player)
    {
        openingPlayer = player;
    }
    OpeningState IOpening.Opening => OpeningState.NewGamePopUp;

    IDisposable disposable;
    void IOpening.Init()
    {
        #region UI表示非表示処理
        openingPlayer.Title.SetActive(false);
        openingPlayer.NewGamePopUp.SetActive(true);
        openingPlayer.Option.SetActive(false);
        openingPlayer.NewMyAccount.SetActive(false);
        #endregion
        OnClickEvent_RemoveInput();

        NewGame_PopUp_Component newGame_PopUp_Component=openingPlayer.NewGamePopUp.GetComponent<NewGame_PopUp_Component>();
        disposable = newGame_PopUp_Component.slider.OnValueChangedAsObservable()
            .Subscribe(_ => {
                float num = _ * 100;
                int a = (int)num;
                newGame_PopUp_Component.text_percent.text = a.ToString();
                
                //ボタンの入力制限処理
                if (a == 100)
                {
                    newGame_PopUp_Component.Yes.interactable = true;
                }
                else
                {
                    newGame_PopUp_Component.Yes.interactable = false;
                }
            });
    }
    void IOpening.Exit()
    {
        //購読終了
        disposable?.Dispose();
        #region UI非表示
        openingPlayer.Title.SetActive(false);
        openingPlayer.NewGamePopUp.SetActive(false);
        openingPlayer.Option.SetActive(false);
        openingPlayer.NewMyAccount.SetActive(false);
        #endregion  
    }
    void IOpening.FixUpdate()
    {

    }
    void IOpening.Update()
    {
    }

    /// <summary>
    /// OnClickのイベントを初期化兼付け直す関数
    /// </summary>
    private void OnClickEvent_RemoveInput()
    {
        NewGame_PopUp_Component newGame_PopUp_Component = openingPlayer.NewGamePopUp.GetComponent<NewGame_PopUp_Component>();
        
        newGame_PopUp_Component.Yes.onClick.RemoveAllListeners();
        newGame_PopUp_Component.Cancel.onClick.RemoveAllListeners();

        newGame_PopUp_Component.Yes.onClick.AddListener(() => 
        {
            //新規アカウント作成画面まで移動
            openingPlayer.newmyaccount();
        }) ;
        newGame_PopUp_Component.Cancel.onClick.AddListener
            (() =>
            {
                //タイトル画面に変換
                openingPlayer.title();
            });
    }
}
