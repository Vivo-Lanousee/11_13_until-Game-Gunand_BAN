using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// PopUpWindow_opetionSelectÇÃComponentäiî[ópÇ…çÏÇ¡ÇΩÇ‡ÇÃ
/// </summary>
public class PopUpWindow_optionSelect : MonoBehaviour
{
    public TextMeshProUGUI popuptext;
    public Button ok;
    public Button cancel;

    public AsyncOperationHandle delete;
    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);

        }
    }
}
