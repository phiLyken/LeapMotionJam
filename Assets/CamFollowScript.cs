using UnityEngine;
using System.Collections;

public class CamFollowScript : MonoBehaviour {

    public Transform m_transTarget;
	
	void LateUpdate () {
        transform.LookAt(m_transTarget);
	}
}
