using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// 今後使うつもりがない機能なので今回Singletonではないやり方で制作している
/// </summary>
[Serializable]
public class NewGame_PopUp_Component : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text_percent;
    public Button Yes;
    public Button Cancel;
}
