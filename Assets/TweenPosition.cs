using UnityEngine;
using System.Collections;

public class TweenPosition : TriggerBase {

    public Transform m_transTarget;
    public float m_fSpeed = 2;
    public AnimationCurve m_animCurve;
    public bool m_bOnce = false;

    public override void trigger()
    {
        StartCoroutine(MoveToTransform.SmoothTransitionToTransform(transform, m_transTarget, m_fSpeed, MoveToTransform.UpdateTime.update, m_animCurve));
        if (m_bOnce)
            enabled = false;
    }
}
