using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.AddressableAssets;
/// <summary>
/// �V�i���I�̃��[�h�Ɛ����p
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

    /// <summary>
    /// �V�i���I��\������ׂ̃v���n�u
    /// </summary>
    public GameObject TextPrefab;

    /// <summary>
    /// �V�i���I�܂ł̃p�X
    /// </summary>
    private string Scenario_path = Application.streamingAssetsPath+"/Scenario/";
    /// <summary>
    /// �L�����N�^�[�����G�̃p�X�z��
    /// </summary>
    private string Character_path = Application.streamingAssetsPath + "/CharacterSprite/";

    
    /// <summary>
    /// �V�i���I�f�[�^��ǂݍ��ށB�����̓V�i���I�̖��O�݂̂ŗǂ�
    /// </summary>
    /// <param name="TextPath"></param>
    public void ScenarioInitLoad(string TextPath)
    {
        TextNum = 0;
        string ScenarioPath=Scenario_path + TextPath + ".json";
        
        StreamReader sr = new StreamReader(ScenarioPath);
        string data=sr.ReadToEnd();
        scenarioText=JsonConvert.DeserializeObject<ScenarioText_Component[]>(data);
    }

    /// <summary>
    /// �V�i���I�̃Q�[���I�u�W�F�N�g����-�����ɐe�I�u�W�F�N�g�̎w��
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
        };
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
