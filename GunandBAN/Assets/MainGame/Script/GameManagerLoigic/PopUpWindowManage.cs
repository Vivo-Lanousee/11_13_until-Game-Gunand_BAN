using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// ポップアップWindowを生成する為のシングルトン
/// </summary>
public class PopUpWindowManage : Singleton<PopUpWindowManage>
{
    public GameObject PopUp;
    public PopUpWindow popupwindow;

    AsyncOperationHandle delete;
    /// <summary>
    /// ポップアップWindowを出す。汎用。
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
}
