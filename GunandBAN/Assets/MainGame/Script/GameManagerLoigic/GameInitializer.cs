using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G���g���[�|�C���g
/// </summary>
public class GameInitializer : MonoBehaviour
{
    // ����������
    public static bool IsInitialized { get; private set; } = false;

    //�Q�[���J�n���Ɏ��s�����
    [RuntimeInitializeOnLoadMethod()]
    static void Initialize()
    {
        Debug.Log("�Q�[���J�n");
        //�Q�[���J�n
        GameManager.Instance();
        
    }
}
