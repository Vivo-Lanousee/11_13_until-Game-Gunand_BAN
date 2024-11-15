using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
/// <summary>
/// PopUpWindowÇÃComponentäiî[ópÇ…çÏÇ¡ÇΩÇ‡ÇÃ
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
