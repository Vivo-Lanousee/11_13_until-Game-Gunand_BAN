using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// マップのランダム生成プログラム。
///マッピングをしてそれを生成するプログラムに関しては別である。真似もできない。
///⇒いつか絶対に作る。
///懸念点としては、一応【最初期の敵の数】等のセッティングなどをしてみたい。
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
    /// 確率
    /// </summary>
    public int A_per=60;
    private int B_per=10;
    private int C_per=15;
    private int D_per = 15;


    [SerializeField]
    public GameObject Boad;

    /// <summary>
    /// キーに確率、バリューにタイル
    /// </summary>
    Dictionary<int, GameObject> map;



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

    /// <summary>
    /// マップの大きさとか編集
    /// </summary>
    void Update()
    {
        MapUI();
    }
    void MapUI()
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

        //こっからマウスホイールでの大きさ調整
        //（スクロールビュー使用時、同時に動いてしまうので機能を制限すること）
        RectTransform rect = Boad.GetComponent<RectTransform>();
        float wh = Input.GetAxis("Mouse ScrollWheel");
        rect.localScale += new Vector3(wh, wh, 1);
    }


    /// <summary>
    /// 行数と列数は決めていない
    /// </summary>
    /// <param name="data"></param>
    /// <param name="data2"></param>
    public void MapInstantiate(int data,int data2)
    {
        int FullNum = data * data2;


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
        return;
    }
    /// <summary>
    /// 確率計算
    /// </summary>
    /// <returns></returns>
    public GameObject test()
    {
        //ここでタイルと確率をすべてやっておく。
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
            cumulativeProbability += entry.Key; // 累積確率を加算
            if (randomPoint < cumulativeProbability)
            {
                 
                // 対応するタイルを返す
                return entry.Value; // 例えば、TileA, TileB などを返す
            }
        }
        return null;
    }
}
