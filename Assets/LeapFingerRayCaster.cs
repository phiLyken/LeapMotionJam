using UnityEngine;
using System.Collections;

public class LeapFingerRayCaster : MonoBehaviour {

	LayerMask HitLayers;
	public Vector3 FingerCastPosition;
	public Vector3 FingerCastNormal;

	public float Confidence {
		get {
			return m_hand.GetLeapHand().Confidence;
		}
	}
	
	HandModel m_hand;

	void Update(){
		Cast ();
	}


	void Cast(){


		RaycastHit HitInfo;
		if(Physics.Raycast( new Ray( transform.position, transform.forward), out HitInfo, 10000, HitLayers )){
			Debug.DrawLine( transform.position, HitInfo.point, Color.red );
			FingerCastPosition = HitInfo.point;
			FingerCastNormal = HitInfo.normal;
		} else {
			Debug.DrawRay( transform.position, transform.forward * 100, Color.green);
		}
	}

	public void Init(HandModel h, LayerMask m){
		m_hand = h;
		HitLayers = m;

	}
}
