using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

/// <summary>
/// �f�[�^�̊Ǘ��B�Q�[���̃��W�b�N�͏������ɃQ�[���̃f�[�^�Ǘ��������s���A������
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// �f�[�^�̏����������Ɠo�^�������s
    /// </summary>
   public void UserDataInit()
    {
        Addressables.LoadAssetAsync<TextAsset>("").Completed += _ => 
        { 
        
        };
    }
}
