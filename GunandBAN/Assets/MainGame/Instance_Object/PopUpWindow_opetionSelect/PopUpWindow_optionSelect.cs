using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// PopUpWindow_opetionSelect��Component�i�[�p�ɍ��������
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
