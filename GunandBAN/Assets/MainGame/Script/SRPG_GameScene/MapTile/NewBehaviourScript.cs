using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Boad;
    void OnMouseDrag()
    {
        // マウスの位置をワールド座標に変換して、Boadをその位置に移動
        Vector3 objPos = Camera.main.WorldToScreenPoint(Boad.transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        Boad.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
