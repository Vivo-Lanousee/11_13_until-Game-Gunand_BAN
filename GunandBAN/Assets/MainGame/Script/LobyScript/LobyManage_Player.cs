using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LobyManage_Player : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI Chapter;

    [SerializeField]
    private�@Button GameStart;
    [SerializeField]
    private Button SRPG;
    [SerializeField]
    private Button Stream;

    [SerializeField]
    private Button EarlyTalk;
    private void Start()
    {
        UI_Init();
    }
    public void UI_Init()
    {
        GameManager gameManager = GameManager.Instance();
        Name.text = gameManager.Player.PlayerName;
        
        GameStart.onClick.AddListener(() =>
        {
            PopUpWindowManage popUpWindowManage=PopUpWindowManage.Instance();

            popUpWindowManage.PopUp_Window_optionSelect_Instance(() => {
                SceneManager.LoadScene("EarlyTalk");
            },"�wEarlyTalk�x" +
            "���C�t�������Ԃɂł��邾����肢�I�����s���܂��傤�B" +
            "�������A�Q�[���ɔM�����Ă���Ԃɂ������҂ɑ΂��Ē��ӂ��s�����ƁB3��I������I�Ԃ��ƂŒ��ӂł��܂��B",gameObject);
        });
    }
}

public enum LobyState
{
    Main,
    Setting,
    SelectGame
}