using UnityEngine;
using System.Collections;

public class InverseAdjustToHand : MonoBehaviour {

	Vector3 RelativHandPosition;
	public Transform Anchor;
	void FixedUpdate()
    {

		if( HandController.Instance.GetAllPhysicsHands().Length <= 	1) return;

		HandModel hand = HandController.Instance.GetAllPhysicsHands()[1];

		if(hand != null){

			Vector3 pos = hand.GetWristPosition();
			Vector3 dif = pos - Anchor.position;
			Debug.DrawLine( Anchor.position, pos, Color.red);
			Debug.DrawRay( transform.position, dif, Color.cyan);

			Anchor.position = transform.position - dif;

		}

	}
}
