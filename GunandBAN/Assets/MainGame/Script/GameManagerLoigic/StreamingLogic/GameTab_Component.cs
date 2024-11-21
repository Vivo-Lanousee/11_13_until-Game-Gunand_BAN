using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class GameTab_Component : MonoBehaviour
{
    public TextMeshProUGUI AllUser;
    public TextMeshProUGUI BadUser;
    
    public AsyncOperationHandle delete;
    public void Start()
    {
        UI_Change();
    }

    public void UI_Change()
    {
        GameMains_StreamLogic gameMains_StreamLogic = GameMains_StreamLogic.Instance();
        AllUser.text = (gameMains_StreamLogic.goodUser + gameMains_StreamLogic.badUser).ToString() + "êl";
        BadUser.text = gameMains_StreamLogic.badUser.ToString() + "êl";
    }

    private void OnDestroy()
    {
        if (delete.IsValid())
        {
            Addressables.Release(delete);

        }
    }
}
