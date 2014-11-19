using UnityEngine;
using System.Collections;

public class TweenPosition : TriggerBase {

    public Transform m_transTarget;
    public float m_fSpeed = 2;
    public AnimationCurve m_animCurve;
    public TriggerBase m_triggerWhenFinished = null;

    public override void trigger()
    {
        StopAllCoroutines();
        StartCoroutine(MoveToTransform.SmoothTransitionToTransform(transform, m_transTarget, m_fSpeed, MoveToTransform.UpdateTime.update, m_animCurve));

        if (m_triggerWhenFinished != null)
            Invoke("triggerWhenFinished", m_fSpeed);
    }

    void triggerWhenFinished()
    {
        m_triggerWhenFinished.trigger();
    }
}
