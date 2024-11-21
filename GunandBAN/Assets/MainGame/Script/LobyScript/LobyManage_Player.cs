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
    private　Button GameStart;
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
            },"『EarlyTalk』" +
            "ライフが削られる間にできるだけ上手い選択を行いましょう。" +
            "ただし、ゲームに熱中している間にも視聴者に対して注意を行うこと。3回選択肢を選ぶことで注意できます。",gameObject);
        });
    }
}

public enum LobyState
{
    Main,
    Setting,
    SelectGame
}