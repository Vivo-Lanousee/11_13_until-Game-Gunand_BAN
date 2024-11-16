using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �}�b�v�̃����_�������v���O�����B
///�}�b�s���O�����Ă���𐶐�����v���O�����Ɋւ��Ă͕ʂł���B�^�����ł��Ȃ��B
///�˂�����΂ɍ��B
///���O�_�Ƃ��ẮA�ꉞ�y�ŏ����̓G�̐��z���̃Z�b�e�B���O�Ȃǂ����Ă݂����B
/// </summary>
public class MapRandomGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject TileA;
    [SerializeField]
    private GameObject TileB;
    [SerializeField]
    private GameObject TileC;
    [SerializeField]
    private GameObject TileD;

    /// <summary>
    /// �m��
    /// </summary>
    public int A_per=60;
    private int B_per=10;
    private int C_per=15;
    private int D_per = 15;


    [SerializeField]
    public GameObject Boad;

    /// <summary>
    /// �L�[�Ɋm���A�o�����[�Ƀ^�C��
    /// </summary>
    Dictionary<int, GameObject> map;



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

    /// <summary>
    /// �}�b�v�̑傫���Ƃ��ҏW
    /// </summary>
    void Update()
    {
        MapUI();
    }
    void MapUI()
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

        //��������}�E�X�z�C�[���ł̑傫������
        //�i�X�N���[���r���[�g�p���A�����ɓ����Ă��܂��̂ŋ@�\�𐧌����邱�Ɓj
        RectTransform rect = Boad.GetComponent<RectTransform>();
        float wh = Input.GetAxis("Mouse ScrollWheel");
        rect.localScale += new Vector3(wh, wh, 1);
    }


    /// <summary>
    /// �s���Ɨ񐔂͌��߂Ă��Ȃ�
    /// </summary>
    /// <param name="data"></param>
    /// <param name="data2"></param>
    public void MapInstantiate(int data,int data2)
    {
        int FullNum = data * data2;


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
        return;
    }
    /// <summary>
    /// �m���v�Z
    /// </summary>
    /// <returns></returns>
    public GameObject test()
    {
        //�����Ń^�C���Ɗm�������ׂĂ���Ă����B
        map = new()
        {
            {A_per, TileA},
            {B_per, TileB},
            {C_per, TileC},
            {D_per, TileD}
        };
        float total=0;
        foreach(int teat in map.Keys)
        {
            total += teat;
        }

        float randomPoint = Random.value * total;

        float cumulativeProbability = 0;
        foreach (var entry in map)
        {
            cumulativeProbability += entry.Key; // �ݐϊm�������Z
            if (randomPoint < cumulativeProbability)
            {
                 
                // �Ή�����^�C����Ԃ�
                return entry.Value; // �Ⴆ�΁ATileA, TileB �Ȃǂ�Ԃ�
            }
        }
        return null;
    }
}
