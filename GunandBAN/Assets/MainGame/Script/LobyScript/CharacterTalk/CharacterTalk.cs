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
    private TextMeshProUGUI m_TextMeshPro;
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

            TalkUI.SetActive(true);

            int a= UnityEngine.Random.Range(0,gameManager.Character_Talk.Count);
            m_TextMeshPro.text = gameManager.Character_Talk[a];

            //�����I�ɏ����鏈��
            m_Disposed=Observable.Timer(TimeSpan.FromSeconds(m_TextMeshPro.text.Length+5)).Subscribe(_ =>
                {
                    TalkUI.SetActive(false);
                    Debug.Log("test");
                });
        }
    }
}
