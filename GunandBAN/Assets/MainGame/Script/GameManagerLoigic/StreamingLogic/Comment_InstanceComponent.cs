using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using R3;

public class Comment_InstanceComponent : MonoBehaviour
{
    #region UIComponent
    [Header("Commentイベント格納用")]
    [SerializeField]
    private Button button_one;
    [SerializeField]
    private Button button_two;
    [SerializeField]
    private Button button_three;

    [Header("ボタン内テキスト")]
    [SerializeField]
    private TextMeshProUGUI buttonText_one;
    [SerializeField]
    private TextMeshProUGUI buttonText_two;
    [SerializeField]
    private TextMeshProUGUI buttonText_three;
    [Header("UserName格納用")]
    [SerializeField]
    private TextMeshProUGUI UserName_one;
    [SerializeField]
    private TextMeshProUGUI UserName_two;
    [SerializeField]
    private TextMeshProUGUI UserName_three;
    #endregion

    [Header("その他")]
    [SerializeField]
    private Button None;
    [SerializeField] 
    private TextMeshProUGUI Remit_Text;

    public Image RemitUI;


    public float RemitMax = 5;
    public float RemitCount=5;
    

    IDisposable dispose;

    public AsyncOperationHandle delete;

    /// <summary>
    /// 生成すると自動的に情報が格納されるようにしてあげる。
    /// </summary>
    public void Start()
    {
        Init();
    }
    /// <summary>
    /// 初期化処理
    /// </summary>
    public void Init()
    {
        GameMains_StreamLogic gameMains_StreamLogic = GameMains_StreamLogic.Instance();

        #region 一人目

        //クリックした時、BANする
        button_one.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(gameMains_StreamLogic.current_UserDataNum);
            dispose?.Dispose();
            Remove();
        });
        //コメントの情報を持ってくる。
        //(生成したタイミングで別途、関数でイベントの名前を指定する事
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_one.text = gameMains_StreamLogic.current_User;
        buttonText_one.text = gameMains_StreamLogic.current_Comment;
        #endregion

        # region 2人目

        button_two.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(gameMains_StreamLogic.current_UserDataNum);
            dispose?.Dispose();
            Remove();
        });
        //コメントの情報を持ってくる。
        //(生成したタイミングで別途、関数でイベントの名前を指定する事
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_two.text = gameMains_StreamLogic.current_User;
        buttonText_two.text = gameMains_StreamLogic.current_Comment;
        #endregion

        #region 3人目
        button_three.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(gameMains_StreamLogic.current_UserDataNum);
            dispose?.Dispose();
            Remove();
        });
        //コメントの情報を持ってくる。
        //(生成したタイミングで別途、関数でイベントの名前を指定する事
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_three.text = gameMains_StreamLogic.current_User;
        buttonText_three.text = gameMains_StreamLogic.current_Comment;
        #endregion

        RemitCount = RemitMax;
        dispose = Observable.EveryUpdate().Subscribe(_ =>
        {
            RemitCount -= Time.deltaTime;
            if (RemitCount > 0)
            {

                RemitUI.fillAmount = RemitCount / RemitMax;
            }
            else
            {
                RemitUI.fillAmount = RemitCount / RemitMax;
                dispose?.Dispose();
                Remove();
            }
        }).AddTo(this);

        None.onClick.AddListener(() =>
        {
            dispose?.Dispose();
            Remove();
        });
    }

    /// <summary>
    /// 削除
    /// </summary>
    public void Remove()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);
        }
    }
}
