using UnityEngine;
using System.Collections;

public class TriggerDelay : TriggerBase {

    public float m_fDelay = 1;
    public TriggerBase m_trigger;

    public override void trigger()
    {
        Invoke("triggerDelayed", m_fDelay);
    }

    void triggerDelayed()
    {
        m_trigger.trigger();
    }
}
