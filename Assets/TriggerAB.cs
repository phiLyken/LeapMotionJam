using UnityEngine;
using System.Collections;

public class TriggerAB : TriggerBase {

    public TriggerBase m_triggerA;
    public TriggerBase m_triggerB;

    private enum TriggerState
    {
        A,
        B,
        COUNT
    }

    private TriggerState m_enumTriggerState = TriggerState.A;

    public override void trigger()
    {
        Debug.Log(m_enumTriggerState);

        switch (m_enumTriggerState)
        {
            case TriggerState.A:
                m_triggerA.trigger();
                break;
            case TriggerState.B:
                m_triggerB.trigger();
                break;
        }

        m_enumTriggerState++;
        if (m_enumTriggerState == TriggerState.COUNT)
            m_enumTriggerState = TriggerState.A;
    }
}
