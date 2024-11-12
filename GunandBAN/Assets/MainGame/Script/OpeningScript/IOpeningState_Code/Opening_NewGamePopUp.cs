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
        #region UI�\����\������
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
                
                //�{�^���̓��͐�������
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
        //�w�ǏI��
        disposable?.Dispose();
        #region UI��\��
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
    /// OnClick�̃C�x���g�����������t�������֐�
    /// </summary>
    private void OnClickEvent_RemoveInput()
    {
        NewGame_PopUp_Component newGame_PopUp_Component = openingPlayer.NewGamePopUp.GetComponent<NewGame_PopUp_Component>();
        
        newGame_PopUp_Component.Yes.onClick.RemoveAllListeners();
        newGame_PopUp_Component.Cancel.onClick.RemoveAllListeners();

        newGame_PopUp_Component.Yes.onClick.AddListener(() => 
        {
            //�V�K�A�J�E���g�쐬��ʂ܂ňړ�
            openingPlayer.newmyaccount();
        }) ;
        newGame_PopUp_Component.Cancel.onClick.AddListener
            (() =>
            {
                //�^�C�g����ʂɕϊ�
                openingPlayer.title();
            });
    }
}
