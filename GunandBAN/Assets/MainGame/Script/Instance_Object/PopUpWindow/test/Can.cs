using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// テスト用のスクリプト
/// </summary>
public class Can : MonoBehaviour
{
    public GameObject canvas;
    PopUpWindowManage popUpWindow;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitializePopUpWindow());
    }

    IEnumerator InitializePopUpWindow()
    {
        // PopUpWindowManageをインスタンス化してポップアップを表示する
        popUpWindow = PopUpWindowManage.Instance();

        // 非同期でポップアップウィンドウを表示
        popUpWindow.PopUp_Window_Instante("カムチャッカファイアー！！！", this.gameObject);

        // 非同期処理が完了するまで待機する
        yield return new WaitForSeconds(0.1f);  

        // ポップアップが正常に設定されていれば、ボタンを表示
        if (popUpWindow.popupwindow != null)
        {
            Debug.Log(popUpWindow.popupwindow.button);
            //popUpWindow.popupwindow.button.onClick.RemoveAllListeners();
        }
    }
}