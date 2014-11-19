using UnityEngine;
using System.Collections;

public class TriggerGroup : TriggerBase {

    public TriggerBase[] m_arTriggerables;

    public override void trigger()
    {
        for (int i = 0; i < m_arTriggerables.Length; i++)
        {
            m_arTriggerables[i].trigger();
        }
    }
}
