using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.AddressableAssets;
using System;
using R3;
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
    /// Window�̎q�I�u�W�F�N�g
    /// </summary>
    public MessageWindow_component messageWindow_Component;

    /// <summary>
    /// �V�i���I�܂ł̃p�X
    /// </summary>
    private string Scenario_path = Application.streamingAssetsPath+"/Scenario/";
    /// <summary>
    /// �L�����N�^�[�����G�̃p�X�z��
    /// </summary>
    private string Character_path = Application.streamingAssetsPath + "/CharacterSprite/";

    /// <summary>
    /// ���������Observer
    /// </summary>
    IDisposable disposable;
    /// <summary>
    /// �V�i���I�V�[���X�^�[�g�B
    /// �������̓V�i���I�̖��O
    /// �������͐e�I�u�W�F�N�g
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
    /// �V�i���I�f�[�^��ǂݍ��ށB�����̓V�i���I�̖��O�݂̂ŗǂ�
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

            messageWindow_Component=TextPrefab.GetComponent<MessageWindow_component>();
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
