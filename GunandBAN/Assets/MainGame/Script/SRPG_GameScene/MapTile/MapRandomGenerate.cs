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



    //R3で発火させる
    public ReactiveProperty<bool> ts = new ReactiveProperty<bool>(false);

    // マウス座標基準の移動
    private Vector3 lastMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        MapInstantiate(20, 10);

        // tsがtrueになったら、マウス位置を基準にBoadを動かす
        ts.Where(_ => _ == true).Subscribe(_ =>
        {
            lastMousePosition = Input.mousePosition;
        }).AddTo(this);
    }

    // Updateは毎フレーム呼ばれる
    void Update()
    {
        // 右クリックでマウス移動によるボード移動
        if (Input.GetMouseButton(1))  // 右クリックが押されている間
        {
            if (!ts.Value)
                ts.Value = true;  // 初めてドラッグを開始するタイミングでtsをtrueに

            // 現在のマウス位置を取得
            Vector3 currentMousePosition = Input.mousePosition;

            // ボードの移動量を計算（マウスの移動距離）
            Vector3 deltaPosition = currentMousePosition - lastMousePosition;

            // UIのRectTransformを移動させる
            RectTransform rectTransform = Boad.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += new Vector2(deltaPosition.x, deltaPosition.y);  // RectTransformの位置を更新

            // 最後のマウス位置を更新
            lastMousePosition = currentMousePosition;
        }
        else if (ts.Value)
        {
            // 右クリックを離したらtsをfalseにリセット
            ts.Value = false;
        }
    }


    /// <summary>
    /// 行数と列数は決めていない
    /// </summary>
    /// <param name="data"></param>
    /// <param name="data2"></param>
    public void MapInstantiate(int data,int data2)
    {
       
        GameObject[,] map_data = new GameObject[data, data2];
        //データ
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
