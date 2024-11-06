using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainPlayer : MonoBehaviour
{
    private GameMainContext gameMainContext;

    private void Awake()
    {
        gameMainContext = new GameMainContext();
        gameMainContext.MainGame_Init(this,MainGameState.InitTime);
    }

    private void Update() => gameMainContext.MainGame_currentState.Update();
    private void FixedUpdate()=>gameMainContext.MainGame_currentState.FixUpdate();


}
