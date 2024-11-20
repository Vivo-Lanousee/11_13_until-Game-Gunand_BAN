using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScenarioTextManager te=ScenarioTextManager.Instance();
        te.ScenarioInitLoad("po");
    }
}
