using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyTalkEvent_Event_one : ITalkEvent
{
    public EarlyTalkEvent_Event_one(EarlyTalkManager earlyTalkManager) {
        EarlyTalkManager = earlyTalkManager;
        }
    public EarlyTalkManager EarlyTalkManager; 

    void ITalkEvent.Init()
    {

        EarlyTalkManager.messageWindow.TextExChange("" +
            "Event_one_true(HP+10)",
            "Event_one_false");
    }
    void ITalkEvent.TrueEnd()
    {
        Debug.Log("1");
        EarlyTalkManager.EventName = "GoodBye";
    }
    void ITalkEvent.FalseEnd()
    {
        EarlyTalkManager.EventName = "Agreement";
    }

    void ITalkEvent.Update()
    {
    }
}
public class EarlyTalkEvent_Event_two : ITalkEvent
{
    public EarlyTalkEvent_Event_two(EarlyTalkManager earlyTalkManager)
    {
        EarlyTalkManager = earlyTalkManager;
    }

    public EarlyTalkManager EarlyTalkManager;

    void ITalkEvent.Init()
    {
        EarlyTalkManager.messageWindow.TextExChange("" +
            "Event_two_true(HP+10)",
            "Event_two_false");
    }

    void ITalkEvent.TrueEnd()
    {
        Debug.Log("2");

        EarlyTalkManager.EventName = "Praise";
    }

    void ITalkEvent.FalseEnd()
    {
        EarlyTalkManager.EventName = "Support";
    }

    void ITalkEvent.Update()
    {
    }
}

public class EarlyTalkEvent_Event_three : ITalkEvent
{
    public EarlyTalkEvent_Event_three(EarlyTalkManager earlyTalkManager)
    {
        EarlyTalkManager = earlyTalkManager;
    }

    public EarlyTalkManager EarlyTalkManager;

    void ITalkEvent.Init()
    {
        EarlyTalkManager.messageWindow.TextExChange("" +
            "Event_three_true",
            "Event_three_false(HP+10)");
    }

    void ITalkEvent.TrueEnd()
    {
        Debug.Log("3");
        EarlyTalkManager.EventName = "Ok";
    }

    void ITalkEvent.FalseEnd()
    {
        EarlyTalkManager.EventName = "Point";
    }

    void ITalkEvent.Update()
    {
    }
}

public class EarlyTalkEvent_Event_four : ITalkEvent
{
    public EarlyTalkEvent_Event_four(EarlyTalkManager earlyTalkManager)
    {
        EarlyTalkManager = earlyTalkManager;
    }

    public EarlyTalkManager EarlyTalkManager;

    void ITalkEvent.Init()
    {
        EarlyTalkManager.messageWindow.TextExChange("" +
            "Event_four_true(HP+10)",
            "Event_four_false");
    }

    void ITalkEvent.TrueEnd()
    {
        Debug.Log("4");
        EarlyTalkManager.EventName = "Ok";
    }

    void ITalkEvent.FalseEnd()
    {
        EarlyTalkManager.EventName = "Praise";
    }

    void ITalkEvent.Update()
    {
    }
}
