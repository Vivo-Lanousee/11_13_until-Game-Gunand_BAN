using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EarlyTalkManager : MonoBehaviour
{
    /// <summary>
    /// イベント対応表
    /// </summary>
    Dictionary<string, ITalkEvent> keyValue;

    public List<string> Event_Names = new List<string>();

    public int Event_Count = 0;

    public GameObject TextBox=null;
    public MessageWindow_component messageWindow=null;

    public ITalkEvent currentEvent=null;
    AsyncOperationHandle delete;

    /// <summary>
    /// インターフェースから変更がかかる。
    /// </summary>
    public string EventName="";

    public GameObject GameOver;
    public GameObject GameClear;

    public float HP=20;
    public float MaxHP=20;
    public Image HP_bar;
    IDisposable dispose;

    /// <summary>
    /// 各種設定初期化
    /// </summary>
    private void Init()
    {
        Event_Names.AddRange(new string[] {
        "Event_one",
        "Event_two",
        "Event_three",
        "Event_four"}
        );
        keyValue = new Dictionary<string, ITalkEvent>() {
            { "Event_one" , new EarlyTalkEvent_Event_one(this) },
            { "Event_two" , new EarlyTalkEvent_Event_two(this) },
            { "Event_three" , new EarlyTalkEvent_Event_three(this) },
            { "Event_four" , new EarlyTalkEvent_Event_four(this) }
        };
        //ロード
        Addressables.LoadAssetAsync<GameObject>("MessageWindow").Completed += _ =>
        {
            if(_.Result==null)
            {
                return;
            }
            delete = _;

            TextBox=Instantiate(_.Result);
            messageWindow = TextBox.GetComponent<MessageWindow_component>();

            TextBox.transform.SetParent(gameObject.transform, false);

            One_Turn();
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        GameMains_StreamLogic game=GameMains_StreamLogic.Instance();
        game.GameInit(5, 5, gameObject);

        Init();
        
        //ここで体力UI変更のオブザーバーを作成している。
        dispose = Observable.EveryUpdate().Subscribe(_ =>
        {
            HP -= Time.deltaTime;
            if (HP > 0)
            {

                HP_bar.fillAmount = HP / MaxHP;
            }
            else
            {
                HP_bar.fillAmount = HP / MaxHP;
                dispose?.Dispose();
            }
        }).AddTo(this);
    }

    /// <summary>
    /// 一ターン
    /// </summary>
    public void One_Turn()
    {

        GameMains_StreamLogic game = GameMains_StreamLogic.Instance();
        if (game.GameClear==true || game.GameEnd==true)
        {
            GameClear.SetActive(true);
            dispose?.Dispose();
        }
        else if (HP<=0)
        {
            GameOver.SetActive(true);
            dispose?.Dispose();
        }
        else{

            int a = UnityEngine.Random.Range(0, Event_Names.Count);
            currentEvent = keyValue[Event_Names[a]];

            currentEvent.Init();


            messageWindow.True.onClick.RemoveAllListeners();
            messageWindow.False.onClick.RemoveAllListeners();
            messageWindow.True.onClick.AddListener(() =>
            {
                currentEvent.TrueEnd();
                One_Turn();
                Debug.Log("test");
            });

            messageWindow.False.onClick.AddListener(() =>
            {
                currentEvent.FalseEnd();
                One_Turn();
            });

            Event_Count++;
            if (Event_Count % 3 == 0&& Event_Count!=0) {
                Debug.Log("Event発生");

                game.CommentQuestion(gameObject, EventName);
            }

        }
    }

    public void LobbyScene()
    {
        SceneManager.LoadScene("Lobby_Scene");
    }
    public void ReStart()
    {
        SceneManager.LoadScene("EarlyTalk");
    }
}
