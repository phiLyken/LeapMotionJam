using UnityEngine;
using System.Collections;

public class InverseAdjustToHand : MonoBehaviour {

	Vector3 RelativHandPosition;
	public Transform Anchor;
	public Transform HandMovementOffset;
	void FixedUpdate()
    {
		SetAnchor();
	}

	Vector3 OldLocalAnchorPosition;

	void SetAnchor ()
	{
		if (HandController.Instance.GetAllPhysicsHands ().Length <= 1)
			return;

		HandModel hand = HandController.Instance.GetAllPhysicsHands () [1];

		if (hand != null) {


			Anchor.localPosition = JamLeapController.Instance.RightHandCreatePosition ;




		}
	}


	public float HandDistance;


	Vector3 Accelleration;
	void LateUpdate(){
		SetAnchor ();
	}
}
