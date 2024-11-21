using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class Comment_InstanceComponent : MonoBehaviour
{
    [Header("Commentäiî[óp")]
    [SerializeField]
    private Button button_one;
    [SerializeField]
    private Button button_two;
    [SerializeField]
    private Button button_three;
    [Header("UserNameäiî[óp")]
    [SerializeField]
    private TextMeshProUGUI UserName_one;
    [SerializeField]
    private TextMeshProUGUI UserName_two;
    [SerializeField]
    private TextMeshProUGUI UserName_three;

    [Header("ÇªÇÃëº")]
    [SerializeField]
    private Button None;
    [SerializeField] 
    private TextMeshProUGUI Remit_Text;


    public AsyncOperationHandle delete;

    /// <summary>
    /// ê∂ê¨Ç∑ÇÈÇ∆é©ìÆìIÇ…èÓïÒÇ™äiî[Ç≥ÇÍÇÈÇÊÇ§Ç…ÇµÇƒÇ†Ç∞ÇÈÅB
    /// </summary>
    public void Start()
    {
        GameMains_StreamLogic gameMains_Stream = GameMains_StreamLogic.Instance();
        gameMains_Stream.GameInit(1, 1);


        None.onClick.AddListener(() =>
        {

        });
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameMains_StreamLogic gameMains_Stream = GameMains_StreamLogic.Instance();
            gameMains_Stream.UserComment("Ok");
        }
    }

    /// <summary>
    /// çÌèú
    /// </summary>
    public void Remove()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);

        }
    }
}
