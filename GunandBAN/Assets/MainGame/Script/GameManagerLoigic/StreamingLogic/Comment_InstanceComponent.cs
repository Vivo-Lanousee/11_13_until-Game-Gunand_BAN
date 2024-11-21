using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class Comment_InstanceComponent : MonoBehaviour
{
    [Header("Comment格納用")]
    [SerializeField]
    private Button button_one;
    [SerializeField]
    private Button button_two;
    [SerializeField]
    private Button button_three;
    [Header("UserName格納用")]
    [SerializeField]
    private TextMeshProUGUI UserName_one;
    [SerializeField]
    private TextMeshProUGUI UserName_two;
    [SerializeField]
    private TextMeshProUGUI UserName_three;

    [Header("その他")]
    [SerializeField]
    private Button None;
    [SerializeField] 
    private TextMeshProUGUI Remit_Text;


    public AsyncOperationHandle delete;

    /// <summary>
    /// 生成すると自動的に情報が格納されるようにしてあげる。
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
    /// 削除
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
