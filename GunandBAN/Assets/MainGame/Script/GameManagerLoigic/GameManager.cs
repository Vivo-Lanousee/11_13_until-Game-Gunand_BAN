using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// �f�[�^�̊Ǘ��B�Q�[���̃��W�b�N�͏������ɃQ�[���̃f�[�^�Ǘ��������s��
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// �v���C���[�̃f�[�^�B��{�������玝���Ă���B
    /// </summary>
    public PlayerDataComponent Player;

    private string playerdatapath= "/PlayerData.json";

    /// <summary>
    /// �v���C���[�f�[�^�̏���������
    /// </summary>
   public void UserDataInit()
    {
        PlayerDataComponent playerDataInit = new PlayerDataComponent() { 
            PlayerName = "",Chapter ="NewGame",Level=1,UserExp=0,
            SRPGGameLevel=1
        };

        var player=JsonConvert.SerializeObject(playerDataInit);

        Debug.Log(player);
        
        using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + playerdatapath, false, System.Text.Encoding.UTF8))
        {
            streamWriter.Write(player);
        }
    }

    /// <summary>
    /// ���O�X�V����
    /// </summary>
    /// <param name="UpdateName"></param>
    public void UserDataNameUpdate(string UpdateName) {

        PlayerDataComponent playerdata;
        using (StreamReader stream = new StreamReader(Application.streamingAssetsPath + playerdatapath))
        {
            string data = stream.ReadToEnd();
            playerdata = JsonConvert.DeserializeObject<PlayerDataComponent>(data);
        }

        playerdata.PlayerName =UpdateName;
 
        //�f�[�^�������ݏ���
        using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + playerdatapath, false, System.Text.Encoding.UTF8))
        {
            var push=JsonConvert.SerializeObject(playerdata);
            streamWriter.Write(push);
        }
    }

    /// <summary>
    /// Player�f�[�^Json����̃f�[�^�_�E�����[�h
    /// </summary>
    public void PlayerDataDownLoad()
    {
        StreamReader stream = new StreamReader(Application.streamingAssetsPath + playerdatapath);
        string data = stream.ReadToEnd();
        PlayerDataComponent playerdata = JsonConvert.DeserializeObject<PlayerDataComponent>(data);
        Player = playerdata;
    }

    /// <summary>
    /// �Z�[�u�@�\
    /// </summary>
    public void PlayerSave()
    {
        using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + playerdatapath, false, System.Text.Encoding.UTF8))
        {
            var push = JsonConvert.SerializeObject(Player);
            streamWriter.Write(push);
        }
    }

    /// <summary>
    /// �Q�[���I�����I�[�g�Z�[�u�i������g�p�����o�O���z�肳��邽�ߒ��Ӂj
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("Check OnApplicationQuit");
        PlayerSave();
    }
}
