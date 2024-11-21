using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyTalkManager : MonoBehaviour
{
    /// <summary>
    /// イベント対応表
    /// </summary>
    Dictionary<string, ITalkEvent> m_;

    public List<string> Event_Names = new List<string>();

    public int Event_Count = 0;
    public int Event_Count2 = 0;
    private void Init()
    {
        Event_Names.AddRange(new string[] {
        "Event_one",
        "Event_two",
        "Event_three",
        "Event_four",
        "Event_five",
        "Event_six",
        "Event_seven",
        "Event_eight",
        "Event_nine",
        "Event_ten"}
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DictionarySetting()
    {
        
    }
}
