using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour�̃V���O���g����
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T instance;

    /// <summary>
    /// ���擾�y�ѐ���
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
