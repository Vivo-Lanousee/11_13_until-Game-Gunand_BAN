using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// PopUpWindow��Component�i�[�p�ɍ��������
/// </summary>
public class PopUpWindow : MonoBehaviour
{
    public TextMeshProUGUI popuptext;
    public Button button;

    public AsyncOperationHandle delete;
    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);

        }
    }
}
