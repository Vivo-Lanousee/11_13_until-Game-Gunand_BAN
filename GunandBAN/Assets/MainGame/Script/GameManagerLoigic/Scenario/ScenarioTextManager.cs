using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// �V�i���I�̃��[�h�p�B
/// </summary>
public class ScenarioTextManager : Singleton<ScenarioTextManager>
{
    /// <summary>
    /// �V�i���I���e��}�����郊�X�g
    /// </summary>
    public ScenarioText_Component[] scenarioText;

    public ScenarioText_Component[] TrueText;
    public ScenarioText_Component[] FalseText;

    /// <summary>
    /// ���݂̃e�L�X�g�ԍ�
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
    /// ���̕����@�\
    /// </summary>
    public void NextScenario()
    {
        //���򏈗�
        if (scenarioText[TextNum].branch)
        {
            TextNum = 0;
            //����V�i���I��}������
            scenarioText = scenarioText[TextNum].branch_scenario_true;
            
        }
    }
}
