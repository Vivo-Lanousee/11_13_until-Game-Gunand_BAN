using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour‚ÌƒVƒ“ƒOƒ‹ƒgƒ“‰»
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected static T instance;

    /// <summary>
    /// î•ñæ“¾‹y‚Ñ¶¬
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
