using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// ポップアップWindowを生成する為のシングルトン
/// </summary>
public class PopUpWindowManage : Singleton<PopUpWindowManage>
{
    public GameObject PopUp;
    public GameObject PopUp_Select;
    public PopUpWindow popupwindow;
    public PopUpWindow_optionSelect popupwindow_optionselect;

    AsyncOperationHandle delete;
    /// <summary>
    /// ポップアップWindowを出す。汎用。
    /// 第一引数にポップアップ内のテキスト。
    /// 第二引数は親オブジェクトを指定
    /// </summary>
    public void PopUp_Window_Instante(string Text,GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("PopUpWindow").Completed
            += _ => {
                if (_.Result == null)
                {
                    return;
                }

                //delete = _;
                PopUp = Instantiate(_.Result);
                PopUp.transform.SetParent(Parent.transform, false);
                popupwindow = PopUp.GetComponent<PopUpWindow>();
                popupwindow.delete = _;

                popupwindow.popuptext.text = Text;
                popupwindow.button.onClick.AddListener(() => { 
                    Destroy(PopUp);
                    Addressables.Release(popupwindow.delete);
                });
            };        
    }
    /// <summary>
    /// 確認用ポップアップWindowを出す。
    /// 第一引数には実行時の関数を
    /// 第2引数にポップアップ内のテキスト。
    /// 第3引数は親オブジェクトを指定
    /// </summary>
    /// <param name="Text"></param>
    /// <param name="Parent"></param>
    public void PopUp_Window_optionSelect_Instance(Action action,string Text, GameObject Parent)
    {
        Addressables.LoadAssetAsync<GameObject>("PopUpWindow_optionSelect").Completed
            += _ => {
                if (_.Result == null)
                {
                    return;
                }

                PopUp_Select = Instantiate(_.Result);
                PopUp_Select.transform.SetParent(Parent.transform, false);
                popupwindow_optionselect = PopUp_Select.GetComponent<PopUpWindow_optionSelect>();
                popupwindow_optionselect.delete = _;

                popupwindow_optionselect.popuptext.text = Text;

                //実際の処理は関数第一引数の時に指定するものとする。決定
                popupwindow_optionselect.ok.onClick.AddListener(() => { 
                    action();
                    //ポップアップ消去
                    Destroy(PopUp_Select);
                    Addressables.Release(popupwindow_optionselect.delete);
                }) ;
                
                //キャンセル。ポップアップ消去
                popupwindow_optionselect.cancel.onClick.AddListener(() => {
                    Destroy(PopUp_Select);
                    Addressables.Release(popupwindow_optionselect.delete);
                });
            };
    }
}
