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
    /// �����_���ɑI�΂�閼�O�̃��X�g
    /// </summary>
    public List<string> name_list = new List<string>();

    public List<UserData> UserList = new List<UserData>();

    /// <summary>
    /// �Q�[���̃^�u���
    /// </summary>
    public GameTab_Component gameTab_Component=null;

    /// <summary>
    /// User�𒝂点�鎞�̊
    /// </summary>
    public int current_UserDataNum=0;

    /// <summary>
    /// �ŐV�̃��[�U�[��
    /// </summary>
    public string current_User;
    /// <summary>
    /// �ŐV�̃R�����g
    /// </summary>
    public string current_Comment;

    /// <summary>
    /// ���݂̃��[�U�[��
    /// </summary>
    public int goodUser = 0;
    public int badUser = 0;
    /// <summary>
    /// ���̃C�x���g�l�[��
    /// </summary>
    public string current_EventName="";


    /// <summary>
    /// ������
    /// ��������GoodUser�A��������Bad(Enemy)User�̐l��
    /// </summary>
    /// <param name_list="good"></param>
    /// <param name_list="bad"></param>
    public void GameInit(int good,int bad)
    {
        goodUser = good;
        badUser = bad;
        current_UserDataNum = 0;
        name_list.Clear();
        #region ���O�̃��X�g���쐬�B
        StreamReader stream = new StreamReader(Application.streamingAssetsPath+"/NameList.json");
        string namedata=stream.ReadToEnd();
        JObject key = JObject.Parse(namedata);
        JArray array = key["namelist"] as JArray;
        foreach (var obj in array)
        {
            name_list.Add(obj.ToString());
        }
        #endregion

        #region�@���[�U�[�쐬
        for (int i = 0; i < good; i++) {
            int a = UnityEngine.Random.Range(0, name_list.Count);
            UserList.Add(new UserData {
                UserName = name_list[a],
                Caluma=UnityEngine.Random.Range(71,101) ,
                Comment_Log_List=new List<string>(),
                BAN_onoff = false
            });
        }
        for (int i = 0;i < bad; i++)
        {
            int a = UnityEngine.Random.Range(0, name_list.Count);
            UserList.Add(new UserData {
                UserName = name_list[a],
                Caluma = UnityEngine.Random.Range(0, 31),
                Comment_Log_List = new List<string>(),
                BAN_onoff=false
             });
        }
        #endregion

        //���ԃV���b�t��
        Shuffle<UserData>(UserList);
    }

    /// <summary>
    /// �v�f�̃����_���V���b�t��������֐��B
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
            int k = rng.Next(n + 1); // 0����n�܂ł̃����_���ȃC���f�b�N�X���擾
            (list[k], list[n]) = (list[n], list[k]); // �v�f�����ւ�
        }
    }

    /// <summary>
    /// �Ō�̏��ԂɂȂ����Ƃ��ABAN���ꂽ�l�Ԃ����X�g����폜���Ă���
    /// </summary>
    public void RemoveBAN()
    {
        UserList = UserList.Where(userData => userData.BAN_onoff == false).ToList();
    }

    /// <summary>
    /// �Ή����[�U�[
    /// </summary>
    public void OnBAN(int num)
    {
        UserList[num].BAN_onoff = true;
        if (UserList[num].Caluma <= 50)
        {
            badUser -= 1;
        }
        else if (51 <= UserList[num].Caluma)
        {
            goodUser -= 1;
        }
    }

    /// <summary>
    /// 1User�̃R�����g�𒊏o����X�N���v�g
    /// </summary>
    public void UserComment(string EventName)
    {
        //�Ō�ɂȂ����珇�Ԃ�0�ɖ߂�����(BAN�������̂�S�č폜�j
        if (UserList.Count <= current_UserDataNum)
        {
            current_UserDataNum = 0;
            RemoveBAN();
            Shuffle<UserData>(UserList);
        }

        #region�@�P������
        string Caluma = "Good";
        //50�ȉ�or51�ȏ�
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
        
        //�f�[�^���o
        string x =key[Caluma+"_"+EventName+UnityEngine.Random.Range(1,3).ToString()].ToString();
        
        //�f�[�^�i�[
        UserList[current_UserDataNum].Comment_Log_List.Add(x);
        current_Comment = x;
        current_User = UserList[current_UserDataNum].UserName;

        current_UserDataNum ++;
    }

    /// <summary>
    /// �^�uUI�𐶐��A�_�E�����[�h
    /// </summary>
    public void TabCreate(GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("").Completed += _ =>
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


    //
    public void CommentQuestion(GameObject Parent)
    {

    }
}