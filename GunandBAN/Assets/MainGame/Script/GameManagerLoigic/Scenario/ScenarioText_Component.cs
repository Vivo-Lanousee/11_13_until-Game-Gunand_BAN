using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V�i���I�𗬂��K�v�ȕϐ�
/// </summary>
public class ScenarioText_Component
{
    public int Id;
    public string Name;
    public string Text;
    //���o���ɕK�v�������ꍇ���O�ŌĂяo�����B
    public string EventName;
    /// <summary>
    /// �u�����`����ŃV�i���I���e�̕ύX
    /// </summary>
    public bool branch;
    /// <summary>
    /// ����݂莞�Ɏg���R���|�[�l���g�B���i�͎g��Ȃ��B
    /// </summary>
    public ScenarioText_Component[] branch_scenario_one;
    public ScenarioText_Component[] branch_scenario_two;
}
