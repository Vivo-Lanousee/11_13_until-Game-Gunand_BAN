using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Newtonsoft.Json;

/// <summary>
/// �V�i���I�̃��[�h�p�B
/// </summary>
public class ScenarioTextManager : Singleton<ScenarioTextManager>
{
    /// <summary>
    /// �V�i���I���e��}�����郊�X�g
    /// </summary>
    public ScenarioText_Component[] scenarioText;
    /// <summary>
    /// ���݂̃e�L�X�g�ԍ�
    /// </summary>
    public int TextNum = 0;

    public GameObject TextPrefab;


    /// <summary>
    /// ���[�h�̉���p-�V�i���I���^�f�[�^�̏ꍇ
    /// </summary>
    AsyncOperationHandle MetaScenariohandle;
    /// <summary>
    /// ���[�h�̉���p-�e�L�X�g�f�[�^�̏ꍇ
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
        //���򏈗�
        if (scenarioText[TextNum].branch)
        {
            TextNum = 0;
            //����V�i���I��}������
            scenarioText = scenarioText[TextNum].branch_scenario_one;
            
            
        }
    }
    /// <summary>
    /// �������������[�X����B
    /// </summary>
    private void MemoryRelease()
    {
        Addressables.Release(Texthandle);
    }
    private void OnDestroy()
    {
        
    }
}
