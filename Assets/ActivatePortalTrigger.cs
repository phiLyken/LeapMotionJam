using UnityEngine;
using System.Collections;

public class ActivatePortalTrigger : TriggerBase {

    public Portal m_portal;
    public bool m_bAtStart = false;

    void Start()
    {
        if (m_bAtStart)
            trigger();
    }

    public override void trigger()
    {
        PortalManager.Instance.ActivatePortat(m_portal);
    }
}
