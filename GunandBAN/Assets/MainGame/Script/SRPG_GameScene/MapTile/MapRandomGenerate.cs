using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapRandomGenerate : MonoBehaviour
{
    [SerializeField]
    private GameObject game;
    [SerializeField]
    public GameObject Boad;

    // Start is called before the first frame update
    void Start()
    {
        MapInstantiate(20,10);
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
                map_data[x, y] = Instantiate(game,new Vector3(x*100,y*100,0f),Quaternion.identity);
                map_data[x, y].transform.SetParent(Boad.transform, false);
            }
        }
        //Boad.transform.position -= map_data[0, 0].transform.position;
    }
}
