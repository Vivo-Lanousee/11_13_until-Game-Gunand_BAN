using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;

/// <summary>
/// データの管理。ゲームのロジックは書かずにゲームのデータ管理だけを行う
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// プレイヤーのデータ。基本ここから持ってくる。
    /// </summary>
    public PlayerDataComponent Player;

    /// <summary>
    /// キャラクターのセリフを入れる
    /// </summary>
    public List<string> Character_Talk=new List<string>();

    private string playerdatapath= "/PlayerData.json";

    /// <summary>
    /// プレイヤーデータの初期化処理
    /// </summary>
   public void UserDataInit()
    {
        PlayerDataComponent playerDataInit = new PlayerDataComponent() { 
            PlayerName = "",Chapter ="NewGame",Level=1,UserExp=0,
            SRPGGameLevel=1,CharacterData="Null"
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
    /// <param name_list="UpdateName"></param>
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
    /// キャラクターチェンジ機能
    /// </summary>
    /// <param name_list="Character"></param>
    public void CharacterChange(string Character)
    {
        //リセット
        Character_Talk.Clear();
        //キャラクターデータを入れていく
        Player.CharacterData = Character;
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/CharacterSprite/CharacterData.json");
        string charadata = reader.ReadToEnd();
        JObject obje = JObject.Parse(charadata);

        // キャラクターの LobyTalk データを取得
        if (obje[Character] != null && obje[Character]["LobyTalk"] != null)
        {
            // LobyTalk の内容を Character_Talk に格納
            JArray lobyTalkArray = (JArray)obje[Character]["LobyTalk"];
            foreach (var talk in lobyTalkArray)
            {
                // 文字列として Character_Talk に追加
                Character_Talk.Add(talk.ToString());
            }
        }
        else
        {
            // 指定されたキャラクターが JSON に存在しない場合の処理
            Console.WriteLine("指定されたキャラクターがデータに存在しません");
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
