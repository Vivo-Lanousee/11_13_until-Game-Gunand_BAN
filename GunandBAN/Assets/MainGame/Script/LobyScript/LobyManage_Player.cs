using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class LobyManage_Player : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Name;
    [SerializeField]
    private TextMeshProUGUI Chapter;
    private void Start()
    {
        UI_Init();
    }
    public void UI_Init()
    {
        GameManager gameManager = GameManager.Instance();
        Name.text = gameManager.Player.PlayerName;
    }
}
