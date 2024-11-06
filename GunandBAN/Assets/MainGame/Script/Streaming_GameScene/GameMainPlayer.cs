using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainPlayer : MonoBehaviour
{
    private GameMainContext gameMainContext;

    private void Update() => gameMainContext.MainGame_currentState.Update();
}
