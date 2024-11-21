using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System;

/// <summary>
/// 
/// </summary>
public class GameMains_StreamLogic : Singleton<GameMains_StreamLogic>
{
    /// <summary>
    /// ランダムに選ばれる名前のリスト
    /// </summary>
    public List<string> name_list = new List<string>();

    public List<UserData> UserList = new List<UserData>();


    /// <summary>
    /// Userを喋らせる時の基準
    /// </summary>
    public int current_UserDataNum=0;

    /// <summary>
    /// 最新のユーザー名
    /// </summary>
    public string current_User;
    /// <summary>
    /// 最新のコメント
    /// </summary>
    public string current_Comment;


    /// <summary>
    /// 初期化
    /// 第一引数はGoodUser、第二引数にBad(Enemy)Userの人数
    /// </summary>
    /// <param name_list="good"></param>
    /// <param name_list="bad"></param>
    public void GameInit(int good,int bad)
    {
        current_UserDataNum = 0;

        name_list.Clear();
        #region 名前のリストを作成。
        StreamReader stream = new StreamReader(Application.streamingAssetsPath+"/NameList.json");
        string namedata=stream.ReadToEnd();
        JObject key = JObject.Parse(namedata);
        JArray array = key["namelist"] as JArray;
        foreach (var obj in array)
        {
            name_list.Add(obj.ToString());
        }
        #endregion

        #region　ユーザー作成
        for (int i = 0; i < good; i++) {
            int a = UnityEngine.Random.Range(0, name_list.Count);
            UserList.Add(new UserData {
                UserName = name_list[a],
                Caluma=UnityEngine.Random.Range(71,101) ,
                Comment_Log_List=new List<string>()});
        }
        for (int i = 0;i < bad; i++)
        {
            int a = UnityEngine.Random.Range(0, name_list.Count);
            UserList.Add(new UserData {
                UserName = name_list[a],
                Caluma = UnityEngine.Random.Range(0, 31),
                Comment_Log_List = new List<string>()
             });
        }
        #endregion

        //順番シャッフル
        Shuffle<UserData>(UserList);
    }

    /// <summary>
    /// 要素のランダムシャッフルをする関数。
    /// </summary>
    /// <typeparam name_list="T"></typeparam>
    /// <param name_list="list"></param>
    public void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1); // 0からnまでのランダムなインデックスを取得
            (list[k], list[n]) = (list[n], list[k]); // 要素を入れ替え
        }
    }

    /// <summary>
    /// 1Userのコメントを抽出するスクリプト
    /// </summary>
    public void UserComment(string EventName)
    {
        #region　善悪判定
        string Caluma = "Good";
        //50以下or51以上
        if (UserList[current_UserDataNum].Caluma <= 50)
        {
            Caluma = "Bad";
        }
        else if (51 <= UserList[current_UserDataNum].Caluma)
        {
            Caluma = "Good";
        }
        #endregion
        StreamReader stream = new StreamReader(Application.streamingAssetsPath + "/Comment/Comment_"+Caluma +".json");
        string namedata = stream.ReadToEnd();
        JObject key = JObject.Parse(namedata);
        
        //データ抽出
        string x =key[Caluma+"_"+EventName+UnityEngine.Random.Range(1,3).ToString()].ToString();
        
        //データ格納
        UserList[current_UserDataNum].Comment_Log_List.Add(x);
        current_Comment = x;
        current_User = UserList[current_UserDataNum].UserName;

        current_UserDataNum ++;

        //
        if (UserList.Count <= current_UserDataNum)
        {
            current_UserDataNum = 0;
        }
    }


}
