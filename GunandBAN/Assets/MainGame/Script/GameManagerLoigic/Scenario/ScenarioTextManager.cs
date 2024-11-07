using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json;

/// <summary>
/// シナリオのロード用。
/// </summary>
public class ScenarioTextManager : Singleton<ScenarioTextManager>
{
    /// <summary>
    /// シナリオ内容を挿入するリスト
    /// </summary>
    public ScenarioText_Component[] scenarioText;
    /// <summary>
    /// 現在のテキスト番号
    /// </summary>
    public int TextNum = 0;

    public GameObject TextPrefab;


    /// <summary>
    /// ロードの解放用-シナリオメタデータの場合
    /// </summary>
    AsyncOperationHandle MetaScenariohandle;
    /// <summary>
    /// ロードの解放用-テキストデータの場合
    /// </summary>
    AsyncOperationHandle Texthandle;
    public void ScenarioInit(string TextPath)
    {
        TextNum = 0;
        Addressables.LoadAssetAsync<TextAsset>(TextPath).Completed += _ =>
        {
            if (_.Result== null){
                return;
            }
            Texthandle = _;
            TextAsset a=_.Result;
            string Text=a.ToString();
            scenarioText=JsonConvert.DeserializeObject<ScenarioText_Component[]>(Text);
        };
    }

    public void Prefab()
    {

    }
    public void NextScenario()
    {
        //分岐処理
        if (scenarioText[TextNum].branch)
        {
            TextNum = 0;
            //分岐シナリオを挿入する
            scenarioText = scenarioText[TextNum].branch_scenario_one;
            
            
        }
    }
    /// <summary>
    /// メモリをリリースする。
    /// </summary>
    private void MemoryRelease()
    {
        Addressables.Release(Texthandle);
    }
    private void OnDestroy()
    {
        
    }
}
