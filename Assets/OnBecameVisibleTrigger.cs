using UnityEngine;
using System.Collections;

public class OnBecameVisibleTrigger : TriggerBase {

    public bool m_bOnce = false;
    public TriggerBase m_trigger;
	
	void OnBecameVisible () {
        Debug.Break();
        trigger();
	}

    public override void trigger()
    {
        m_trigger.trigger();
    }
}
