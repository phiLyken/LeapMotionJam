using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour
{
    public TriggerBase m_trigger;
    public bool m_bOnce = true;

    HingeJoint m_hingeJoint;
    float triggerAngleArea = 20;

    bool m_bNeedsReset = false;

    void Awake()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (!m_bNeedsReset)
        {
            if ((transform.localRotation.eulerAngles.x > (m_hingeJoint.limits.max - triggerAngleArea) &&
                transform.localRotation.eulerAngles.x < (m_hingeJoint.limits.max)) ||
                (transform.localRotation.eulerAngles.x > (360.0f + m_hingeJoint.limits.min) &&
                transform.localRotation.eulerAngles.x < (360.0f + m_hingeJoint.limits.min + triggerAngleArea)))
            {
                Debug.Log("Trigger");
                m_trigger.trigger();

                m_bNeedsReset = true;

                if (m_bOnce)
                    this.enabled = false;
            }
        }
        else
        {
            if ((transform.localRotation.eulerAngles.x < (m_hingeJoint.limits.max - triggerAngleArea) &&
                transform.localRotation.eulerAngles.x > 0) ||
                (transform.localRotation.eulerAngles.x > (360.0f + m_hingeJoint.limits.min + triggerAngleArea) &&
                transform.localRotation.eulerAngles.x < 360.0f))
            {
                m_bNeedsReset = false;
            }
        }
    }
}
