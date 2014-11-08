using UnityEngine;
using System.Collections;

public class MoveToBone : MonoBehaviour {

    public enum Target
    {
        thumb,
        index,
        middle,
        ring,
        pinky,
        palm
    }

    public enum Bone
    {
        bone1,
        bone2,
        bone3
    }

    public Target m_eTarget;
    public Bone m_eBone;

    private Vector3 m_v3CurrentVelocity;
    private float m_fSmoothTime = 0.1f;

    private bool m_bDissolve = false;
	
	// Update is called once per frame
	void Update () {
        GameObject m_goTarget = GameObject.Find(m_eTarget.ToString());
        if (m_goTarget != null && !m_bDissolve)
        {
            rigidbody.isKinematic = true;
            collider.enabled = false;
            Transform m_transTarget = m_goTarget.transform;
            if (m_eTarget != Target.palm)
                m_transTarget = m_transTarget.Find(m_eBone.ToString());

            transform.position = Vector3.SmoothDamp(transform.position, m_transTarget.position, ref m_v3CurrentVelocity, m_fSmoothTime);
        }
        else
        {
            if (collider.enabled == false)
            {
                collider.enabled = true;
                rigidbody.isKinematic = false;
                rigidbody.AddForce(m_v3CurrentVelocity, ForceMode.Impulse);
            }
            m_bDissolve = false;
        }
	}

    public void dissolve()
    {
        m_bDissolve = true;
    }
}

//using UnityEngine;
//using System.Collections;

//public class MoveToBone : MonoBehaviour {

//    public enum Target
//    {
//        thumb,
//        index,
//        middle,
//        ring,
//        pinky,
//        palm
//    }

//    public enum Bone
//    {
//        bone1,
//        bone2,
//        bone3
//    }

//    public Target m_eTarget;
//    public Bone m_eBone;

//    public AnimationCurve m_animationCurve;

//    private Vector3 _v3InitialPos = Vector3.zero;
//    private float _fPos = 0;
	
//    // Update is called once per frame
//    void Update () {
//        GameObject m_goTarget = GameObject.Find(m_eTarget.ToString());
//        if (m_goTarget != null)
//        {
//            if (_v3InitialPos == Vector3.zero)
//                _v3InitialPos = transform.position;
//            _fPos += Time.deltaTime;
//            _fPos = Mathf.Clamp01(_fPos);
//            rigidbody.isKinematic = true;
//            collider.enabled = false;
//            Transform m_transTarget = m_goTarget.transform;
//            if (m_eTarget != Target.palm)
//                m_transTarget = m_transTarget.Find(m_eBone.ToString());

//            float _fForce = 100;
//            Vector3 _v3Dir = m_transTarget.position - transform.position;
//            _v3Dir.Normalize();
//            //rigidbody.AddForce(_v3Dir * _fForce);
//            transform.position = Vector3.Lerp(_v3InitialPos, m_transTarget.position, m_animationCurve.Evaluate(_fPos));
//        }
//        else
//        {
//            collider.enabled = true;
//            rigidbody.isKinematic = false;
//            _fPos = 0;
//            _v3InitialPos = Vector3.zero;
//        }
//    }
//}
