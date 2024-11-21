using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.AddressableAssets;
using System;
using R3;
/// <summary>
/// シナリオのロードと生成用
/// </summary>
public class ScenarioTextManager : Singleton<ScenarioTextManager>
{
    /// <summary>
    /// シナリオ内容を挿入するリスト
    /// </summary>
    public ScenarioText_Component[] scenarioText;

    public ScenarioText_Component[] TrueText;
    public ScenarioText_Component[] FalseText;

    /// <summary>
    /// 現在のテキスト番号
    /// </summary>
    public int TextNum = 0;

    /// <summary>
    /// シナリオを表示する為のプレハブ
    /// </summary>
    public GameObject TextPrefab;
    /// <summary>
    /// Windowの子オブジェクト
    /// </summary>
    public MessageWindow_component messageWindow_Component;

    /// <summary>
    /// シナリオまでのパス
    /// </summary>
    private string Scenario_path = Application.streamingAssetsPath+"/Scenario/";
    /// <summary>
    /// キャラクター立ち絵のパス想定
    /// </summary>
    private string Character_path = Application.streamingAssetsPath + "/CharacterSprite/";

    /// <summary>
    /// 文字送りのObserver
    /// </summary>
    IDisposable disposable;
    /// <summary>
    /// シナリオシーンスタート。
    /// 第一引数はシナリオの名前
    /// 第二引数は親オブジェクト
    /// </summary>
    public void Scenario_Start(string TextPath,GameObject Parent)
    {
        ScenarioInitLoad(TextPath);
        ScenarioInstantiate(Parent);

        disposable=Observable.EveryUpdate()
            .Where(_ => Input.GetKeyUp(KeyCode.Escape))
            .Subscribe(_ => { Debug.Log("test"); }).AddTo(this);
    }


    /// <summary>
    /// シナリオデータを読み込む。引数はシナリオの名前のみで良い
    /// </summary>
    /// <param name_list="TextPath"></param>
    public void ScenarioInitLoad(string TextPath)
    {
        TextNum = 0;
        string ScenarioPath=Scenario_path + TextPath + ".json";
        
        StreamReader sr = new StreamReader(ScenarioPath);
        string data=sr.ReadToEnd();
        scenarioText=JsonConvert.DeserializeObject<ScenarioText_Component[]>(data);
    }

    /// <summary>
    /// シナリオのゲームオブジェクト生成-引数に親オブジェクトの指定
    /// </summary>
    public void ScenarioInstantiate(GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("MessageWindow").Completed += _ =>
        {
            if(_.Result ==null)
            {
                return;
            }
            TextPrefab=Instantiate(_.Result);
            TextPrefab.transform.SetParent(Parent.transform, false);

            messageWindow_Component=TextPrefab.GetComponent<MessageWindow_component>();
        };
    }

    /// <summary>
    /// 次の文字機能
    /// </summary>
    public void NextScenario()
    {
        //分岐処理
        if (scenarioText[TextNum].branch)
        {
            TextNum = 0;
            //分岐シナリオを挿入する
            scenarioText = scenarioText[TextNum].branch_scenario_true;
            
        }
    }
}
