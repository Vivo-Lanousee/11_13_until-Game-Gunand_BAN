using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Boad;
    void OnMouseDrag()
    {
        // �}�E�X�̈ʒu�����[���h���W�ɕϊ����āABoad�����̈ʒu�Ɉړ�
        Vector3 objPos = Camera.main.WorldToScreenPoint(Boad.transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        Boad.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
}
