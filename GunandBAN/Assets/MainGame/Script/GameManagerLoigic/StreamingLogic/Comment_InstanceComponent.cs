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

    /// <summary>
    /// 試してみたいことがある。
    /// </summary>
    public int A;
    public int B;
    public int C;


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

        #region 1人目

        //外部から数値を取ってこないと、クリックした時の変数の値になってしまうのでバグってしまうので外部で一度格納する
        int num_a = gameMains_StreamLogic.current_UserDataNum;
        A = gameMains_StreamLogic.UserList[num_a].Id;

        Debug.Log("テストAは"+num_a);
        //クリックした時、BANする
        button_one.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(A);
            dispose?.Dispose();
            Remove();
        });

        /////今のままじゃなんか知らんけどインデックス番号がリセット以降もってこれない？！なんで？！

        //コメントの情報を持ってくる。
        //(生成したタイミングで別途、関数でイベントの名前を指定する事
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_one.text = gameMains_StreamLogic.current_User;
        buttonText_one.text = gameMains_StreamLogic.current_Comment;
        #endregion

        # region 2人目
        int num_b = gameMains_StreamLogic.current_UserDataNum;
        Debug.Log("テストBは"+num_b);
        B = gameMains_StreamLogic.UserList[num_b].Id;
        

        button_two.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(B);
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
        int num_c = gameMains_StreamLogic.current_UserDataNum;
        C=gameMains_StreamLogic.UserList[num_c].Id;
        

        button_three.onClick.AddListener(() =>
        {
            gameMains_StreamLogic.OnBAN(C);
            dispose?.Dispose();
            Remove();
        });
        //コメントの情報を持ってくる。
        //(生成したタイミングで別途、関数でイベントの名前を指定する事
        gameMains_StreamLogic.UserComment(gameMains_StreamLogic.current_EventName);
        UserName_three.text = gameMains_StreamLogic.current_User;
        buttonText_three.text = gameMains_StreamLogic.current_Comment;
        #endregion

        //ゲージ減少
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
