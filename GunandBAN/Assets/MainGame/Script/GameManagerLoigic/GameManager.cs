using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

/// <summary>
/// データの管理。ゲームのロジックは書かずにゲームのデータ管理だけを行う
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// プレイヤーのデータ。基本ここから持ってくる。
    /// </summary>
    public PlayerDataComponent Player;

    private string playerdatapath= "/PlayerData.json";

    /// <summary>
    /// プレイヤーデータの初期化処理
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
    /// 名前更新処理
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
 
        //データ書き込み処理
        using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + playerdatapath, false, System.Text.Encoding.UTF8))
        {
            var push=JsonConvert.SerializeObject(playerdata);
            streamWriter.Write(push);
        }
    }

    /// <summary>
    /// PlayerデータJsonからのデータダウンロード
    /// </summary>
    public void PlayerDataDownLoad()
    {
        StreamReader stream = new StreamReader(Application.streamingAssetsPath + playerdatapath);
        string data = stream.ReadToEnd();
        PlayerDataComponent playerdata = JsonConvert.DeserializeObject<PlayerDataComponent>(data);
        Player = playerdata;
    }

    /// <summary>
    /// セーブ機能
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
    /// ゲーム終了時オートセーブ（これを使用したバグも想定されるため注意）
    /// </summary>
    private void OnApplicationQuit()
    {
        Debug.Log("Check OnApplicationQuit");
        PlayerSave();
    }
}
