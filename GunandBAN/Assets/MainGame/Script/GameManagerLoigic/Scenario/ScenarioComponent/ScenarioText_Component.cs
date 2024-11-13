using System;
using UnityEngine;

/// <summary>
/// シナリオを流す必要な変数
/// </summary>
[Serializable]
public class ScenarioText_Component
{
    public int Id;
    public string Name;
    public string Text;
    //演出時に必要だった場合名前で呼び出される。
    public string EventName;
    /// <summary>
    /// ブランチ次第でシナリオ内容の変更
    /// </summary>
    public bool branch;
    /// <summary>
    /// 分岐在り時に使うコンポーネント。普段は使わない。
    /// </summary>
    public ScenarioText_Component[] branch_scenario_true;
    public ScenarioText_Component[] branch_scenario_false;
}
