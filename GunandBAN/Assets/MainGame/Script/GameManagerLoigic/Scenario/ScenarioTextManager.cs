using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// シナリオのロード用。
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


    public GameObject TextPrefab;

    private string path = Application.streamingAssetsPath+"/Scenario/";
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="TextPath"></param>
    public void ScenarioInitLoad(string TextPath)
    {
        TextNum = 0;
        string ScenarioPath=path + TextPath + ".json";
        
        StreamReader sr = new StreamReader(ScenarioPath);
        string data=sr.ReadToEnd();
        scenarioText=JsonConvert.DeserializeObject<ScenarioText_Component[]>(data);
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
