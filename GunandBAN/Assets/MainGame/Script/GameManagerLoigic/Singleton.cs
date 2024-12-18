using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviourのシングルトン化
/// </summary>
/// <typeparam name_list="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T instance;

    /// <summary>
    /// 情報取得及び生成
    /// </summary>
    /// <returns></returns>
    public static T Instance()
    {
        if (instance == null)
        {
            var game = new GameObject(typeof(T).Name);
            instance = game.AddComponent<T>();
            DontDestroyOnLoad(game);
        }
        return instance;
    }
}
