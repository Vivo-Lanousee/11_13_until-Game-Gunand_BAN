using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System;
using R3;

/// <summary>
/// Lobby画面のキャラクターが話すやつ（ソシャゲライクの案。）
/// </summary>
public class CharacterTalk : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Image CharaTextFlame;
    [SerializeField]
    private TextMeshProUGUI messageText;
    [SerializeField]
    private GameObject TalkUI;

    [SerializeField]
    private Button A;
    [SerializeField]
    private Button B;

    IDisposable m_Disposed;


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
            m_Disposed?.Dispose();

            StartCoroutine(FadeIn());

            int a= UnityEngine.Random.Range(0,gameManager.Character_Talk.Count);
            messageText.text = gameManager.Character_Talk[a];

            //自動的に消える処理
            m_Disposed=Observable.Timer(TimeSpan.FromSeconds(messageText.text.Length+3)).Subscribe(_ =>
                {
                    StartCoroutine(FadeOut());
                }).AddTo(this);
        }
    }

    public float fadeDuration = 1f;    // フェードにかかる時間

    // 同時にフェードアウトを開始するコルーチン
    public IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        Color startColorImage = CharaTextFlame.color; // Imageの現在の色（アルファ値を含む）
        Color targetColorImage = new Color(startColorImage.r, startColorImage.g, startColorImage.b, 0f); // 完全に透明な色（アルファ値0）

        Color startColorText = messageText.color; // TMPの現在の色（アルファ値を含む）
        Color targetColorText = new Color(startColorText.r, startColorText.g, startColorText.b, 0f); // 完全に透明な色（アルファ値0）

        // 同時にフェードアウト処理
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;

            // Imageのアルファを補間
            CharaTextFlame.color = Color.Lerp(startColorImage, targetColorImage, timeElapsed / fadeDuration);

            // TMPのアルファを補間
            messageText.color = Color.Lerp(startColorText, targetColorText, timeElapsed / fadeDuration);

            yield return null;
        }

        // 最終的に透明にする
        CharaTextFlame.color = targetColorImage;
        messageText.color = targetColorText;
    }

    // 同時にフェードインを開始するコルーチン
    public IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        Color startColorImage = CharaTextFlame.color; // Imageの現在の色
        Color targetColorImage = new Color(startColorImage.r, startColorImage.g, startColorImage.b, 1f); // 完全に不透明な色（アルファ値1）

        Color startColorText = messageText.color; // TMPの現在の色
        Color targetColorText = new Color(startColorText.r, startColorText.g, startColorText.b, 1f); // 完全に不透明な色（アルファ値1）

        // 同時にフェードイン処理
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;

            // Imageのアルファを補間
            CharaTextFlame.color = Color.Lerp(startColorImage, targetColorImage, timeElapsed / fadeDuration);

            // TMPのアルファを補間
            messageText.color = Color.Lerp(startColorText, targetColorText, timeElapsed / fadeDuration);

            yield return null;
        }

        // 最終的に不透明にする
        CharaTextFlame.color = targetColorImage;
        messageText.color = targetColorText;
    }
}
