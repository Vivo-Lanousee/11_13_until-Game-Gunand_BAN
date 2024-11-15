using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapRandomGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject TileA;
    [SerializeField]
    private GameObject TileB;
    [SerializeField]
    private GameObject TileC;
    [SerializeField]
    public GameObject Boad;



    //R3�Ŕ��΂�����
    public ReactiveProperty<bool> ts = new ReactiveProperty<bool>(false);

    // �}�E�X���W��̈ړ�
    private Vector3 lastMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        MapInstantiate(20, 10);

        // ts��true�ɂȂ�����A�}�E�X�ʒu�����Boad�𓮂���
        ts.Where(_ => _ == true).Subscribe(_ =>
        {
            lastMousePosition = Input.mousePosition;
        }).AddTo(this);
    }

    // Update�͖��t���[���Ă΂��
    void Update()
    {
        // �E�N���b�N�Ń}�E�X�ړ��ɂ��{�[�h�ړ�
        if (Input.GetMouseButton(1))  // �E�N���b�N��������Ă����
        {
            if (!ts.Value)
                ts.Value = true;  // ���߂ăh���b�O���J�n����^�C�~���O��ts��true��

            // ���݂̃}�E�X�ʒu���擾
            Vector3 currentMousePosition = Input.mousePosition;

            // �{�[�h�̈ړ��ʂ��v�Z�i�}�E�X�̈ړ������j
            Vector3 deltaPosition = currentMousePosition - lastMousePosition;

            // UI��RectTransform���ړ�������
            RectTransform rectTransform = Boad.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += new Vector2(deltaPosition.x, deltaPosition.y);  // RectTransform�̈ʒu���X�V

            // �Ō�̃}�E�X�ʒu���X�V
            lastMousePosition = currentMousePosition;
        }
        else if (ts.Value)
        {
            // �E�N���b�N�𗣂�����ts��false�Ƀ��Z�b�g
            ts.Value = false;
        }
    }


    /// <summary>
    /// �s���Ɨ񐔂͌��߂Ă��Ȃ�
    /// </summary>
    /// <param name="data"></param>
    /// <param name="data2"></param>
    public void MapInstantiate(int data,int data2)
    {
       
        GameObject[,] map_data = new GameObject[data, data2];
        //�f�[�^
        for (int x=0; x<data;x++ )
        {
            for (int y = 0; y < data2; y++)
            {
                map_data[x, y] = Instantiate(TileA,new Vector3(x*100,y*100,0f),Quaternion.identity);
                map_data[x, y].transform.SetParent(Boad.transform, false);
            }
        }
        //Boad.transform.position -= map_data[0, 0].transform.position;
    }
}
