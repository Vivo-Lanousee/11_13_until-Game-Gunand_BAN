using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISrpg
{
    public OpeningState Opening { get; }
    void Init();
    void Update();
    void FixUpdate();
    void Exit();
}
