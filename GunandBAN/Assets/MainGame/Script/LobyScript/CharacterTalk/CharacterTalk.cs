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
/// Lobby��ʂ̃L�����N�^�[���b����i�\�V���Q���C�N�̈āB�j
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
    /// �N���b�N���̏���
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

            //�����I�ɏ����鏈��
            m_Disposed=Observable.Timer(TimeSpan.FromSeconds(messageText.text.Length+3)).Subscribe(_ =>
                {
                    StartCoroutine(FadeOut());
                }).AddTo(this);
        }
    }

    public float fadeDuration = 1f;    // �t�F�[�h�ɂ����鎞��

    // �����Ƀt�F�[�h�A�E�g���J�n����R���[�`��
    public IEnumerator FadeOut()
    {
        float timeElapsed = 0f;

        Color startColorImage = CharaTextFlame.color; // Image�̌��݂̐F�i�A���t�@�l���܂ށj
        Color targetColorImage = new Color(startColorImage.r, startColorImage.g, startColorImage.b, 0f); // ���S�ɓ����ȐF�i�A���t�@�l0�j

        Color startColorText = messageText.color; // TMP�̌��݂̐F�i�A���t�@�l���܂ށj
        Color targetColorText = new Color(startColorText.r, startColorText.g, startColorText.b, 0f); // ���S�ɓ����ȐF�i�A���t�@�l0�j

        // �����Ƀt�F�[�h�A�E�g����
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;

            // Image�̃A���t�@����
            CharaTextFlame.color = Color.Lerp(startColorImage, targetColorImage, timeElapsed / fadeDuration);

            // TMP�̃A���t�@����
            messageText.color = Color.Lerp(startColorText, targetColorText, timeElapsed / fadeDuration);

            yield return null;
        }

        // �ŏI�I�ɓ����ɂ���
        CharaTextFlame.color = targetColorImage;
        messageText.color = targetColorText;
    }

    // �����Ƀt�F�[�h�C�����J�n����R���[�`��
    public IEnumerator FadeIn()
    {
        float timeElapsed = 0f;

        Color startColorImage = CharaTextFlame.color; // Image�̌��݂̐F
        Color targetColorImage = new Color(startColorImage.r, startColorImage.g, startColorImage.b, 1f); // ���S�ɕs�����ȐF�i�A���t�@�l1�j

        Color startColorText = messageText.color; // TMP�̌��݂̐F
        Color targetColorText = new Color(startColorText.r, startColorText.g, startColorText.b, 1f); // ���S�ɕs�����ȐF�i�A���t�@�l1�j

        // �����Ƀt�F�[�h�C������
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;

            // Image�̃A���t�@����
            CharaTextFlame.color = Color.Lerp(startColorImage, targetColorImage, timeElapsed / fadeDuration);

            // TMP�̃A���t�@����
            messageText.color = Color.Lerp(startColorText, targetColorText, timeElapsed / fadeDuration);

            yield return null;
        }

        // �ŏI�I�ɕs�����ɂ���
        CharaTextFlame.color = targetColorImage;
        messageText.color = targetColorText;
    }
}
