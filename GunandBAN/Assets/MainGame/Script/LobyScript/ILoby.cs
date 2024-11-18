using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoby 
{
    public LobyState lobystate { get; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}
