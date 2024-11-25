using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using UnityEngine.AddressableAssets;

public class GameMains_StreamLogic : Singleton<GameMains_StreamLogic>
{
    /// <summary>
    /// ランダムに選ばれる名前のリスト
    /// </summary>
    public List<string> name_list = new List<string>();

    public List<UserData> UserList = new List<UserData>();

    /// <summary>
    /// ゲームのタブ情報
    /// </summary>
    public GameTab_Component gameTab_Component=null;
    /// <summary>
    /// BAN探索画面情報
    /// </summary>
    public Comment_InstanceComponent comment_InstanceComponent=null;

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
    /// 現在のユーザー数
    /// </summary>
    public int goodUser = 0;
    public int badUser = 0;
    /// <summary>
    /// 今のイベントネーム
    /// </summary>
    public string current_EventName="";

    public bool GameEnd=false;
    public bool GameClear=false;

    /// <summary>
    /// プライマリーキーを設定する時に使用
    /// </summary>
    public int NewPMId_Character=0;

    /// <summary>
    /// 初期化
    /// 第一引数はGoodUser、第二引数にBad(Enemy)Userの人数
    /// </summary>
    /// <param name_list="good"></param>
    /// <param name_list="bad"></param>
    public void GameInit(int good,int bad,GameObject Parent)
    {
        #region データを全てリセット
        GameEnd = false;
        GameClear = false;
        goodUser = good;
        badUser = bad;
        current_UserDataNum = 0;
        NewPMId_Character = 0;
        name_list.Clear();
        #endregion

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
                Id = NewPMId_Character,
                UserName = name_list[a],
                Caluma=UnityEngine.Random.Range(71,101) ,
                Comment_Log_List=new List<string>(),
                BAN_onoff = false
            });
            
            NewPMId_Character++;
        }
        for (int i = 0;i < bad; i++)
        {
            int a = UnityEngine.Random.Range(0, name_list.Count);
            UserList.Add(new UserData {
                Id = NewPMId_Character,
                UserName = name_list[a],
                Caluma = UnityEngine.Random.Range(0, 31),
                Comment_Log_List = new List<string>(),
                BAN_onoff=false
             });
            NewPMId_Character++;
        }
        #endregion

        //順番シャッフル
        Shuffle<UserData>(UserList);

        TabCreate(Parent);
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
    /// 最後の順番になったとき、BANされた人間をリストから削除しておく
    /// </summary>
    public void RemoveBAN()
    {
        UserList = UserList.Where(userData => userData.BAN_onoff == false).ToList();
    }

    /// <summary>
    /// 対応ユーザー
    /// </summary>
    public void OnBAN(int num)
    {
        //BANの判定をする時は全てIDで探す
        UserData user =(UserData)UserList.Where(userdata => userdata.Id == num);
        Debug.Log(user);
        int Ban_Num=UserList.FindIndex(_ => _ == user);
        

        //BANの判定をONにする
        UserList[Ban_Num].BAN_onoff = true;

        if (UserList[Ban_Num].Caluma <= 50)
        {
            badUser -= 1;
        }
        else if (51 <= UserList[Ban_Num].Caluma)
        {
            goodUser -= 1;
        }
        //タブのUIを変更する
        if (gameTab_Component!=null)
        {
            //UIを変更させる。
            gameTab_Component.UI_Change();
        }
        //悪いユーザーが0人になったとき、クリアの判定をオンにする
        if(badUser <= 0)
        {
            GameClear = true;
        }
        //もしUserが3人未満になった場合、ゲームを終了する。
        if(goodUser +badUser <3)
        {
            GameEnd = true;
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
        
        
        //ログに格納しようかって思ったけど流石にやばそう。
        //UserList[current_UserDataNum].Comment_Log_List.Add(x);

        //データ格納
        current_Comment = x;
        current_User = UserList[current_UserDataNum].UserName;

        current_UserDataNum ++;


        //最後になったら順番を0に戻す処理(BANしたものを全て削除）
        if (UserList.Count <= current_UserDataNum)
        {
            Debug.Log("タイミング確認");
            current_UserDataNum = 0;
            RemoveBAN();
            Shuffle<UserData>(UserList);
        }
    }

    /// <summary>
    /// タブUIを生成、ダウンロード
    /// </summary>
    public void TabCreate(GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("GameTab").Completed += _ =>
        {
            if(_.Result == null)
            {
                return;
            }

            GameObject tab=Instantiate(_.Result);
            gameTab_Component=tab.GetComponent<GameTab_Component>();
            gameTab_Component.delete = _;

            tab.transform.SetParent(Parent.transform,false);
        };
    }

    /// <summary>
    /// ユーザーのコメントを複数表示する為のUIを生成。
    /// EventNameを指定しなければ生成しない。
    /// </summary>
    /// <param name="Parent"></param>
    public void CommentQuestion(GameObject Parent,string EventName)
    {
        //Eventの名前を設定
        current_EventName = EventName;

        if (GameEnd != true)
        {
            Addressables.LoadAssetAsync<GameObject>("BanQuestion").Completed += _ =>
            {
                if (_.Result == null)
                {
                    return;
                }
                GameObject tab = Instantiate(_.Result);
                comment_InstanceComponent = tab.GetComponent<Comment_InstanceComponent>();
                comment_InstanceComponent.delete = _;

                tab.transform.SetParent(Parent.transform, false);
            };
        }
    }
}