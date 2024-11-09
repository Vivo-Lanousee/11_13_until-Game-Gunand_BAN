using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningPlayer : MonoBehaviour
{
    public GameObject title;
    public GameObject NewGame;
    public GameObject Option;
    public GameObject NewMyAccount;

    private OpeningContext OpeningContext;

    private void Awake()
    {
        OpeningContext = new OpeningContext();
        OpeningContext.MainGame_Init(this, OpeningState.Title);
    }

    private void Update() => OpeningContext.Opening_currentState.Update();
    private void FixedUpdate() => OpeningContext.Opening_currentState.FixUpdate();


}