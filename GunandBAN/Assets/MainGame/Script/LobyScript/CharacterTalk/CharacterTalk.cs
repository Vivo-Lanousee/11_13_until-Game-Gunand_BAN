using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

/// <summary>
/// Lobby画面のキャラクターが話すやつ（ソシャゲライクの案。）
/// </summary>
public class CharacterTalk : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Image CharaTextFlame;
    [SerializeField]
    private TextMeshProUGUI m_TextMeshPro;
    [SerializeField]
    private GameObject TalkUI;

    [SerializeField]
    private Button A;
    [SerializeField]
    private Button B;

    private void Awake()
    {
        A.onClick.AddListener(() => {
            GameManager gameManager = GameManager.Instance();
            gameManager.CharacterChange("A");
        });
        B.onClick.AddListener(() =>
        {
            GameManager gameManager = GameManager.Instance();
            gameManager.CharacterChange("B");
        });
    }

    /// <summary>
    /// クリック時の処理
    /// </summary>
    /// <param name_list="pointerEventData"></param>
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        GameManager gameManager = GameManager.Instance();
        if(gameManager.Player.CharacterData != null)
        {
            TalkUI.SetActive(true);

            int a=Random.Range(0,gameManager.Character_Talk.Count);
            m_TextMeshPro.text = gameManager.Character_Talk[a];
        }
    }
}
