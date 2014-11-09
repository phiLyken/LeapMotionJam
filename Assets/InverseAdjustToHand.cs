using UnityEngine;
using System.Collections;

public class InverseAdjustToHand : MonoBehaviour {

	Vector3 RelativHandPosition;
	public Transform Anchor;

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

			Vector3 pos = hand.GetWristPosition ();
			Vector3 dif = pos - Anchor.position;
			Vector3 zOffset = transform.forward * YAccelleration;
			Vector3 newAnchorPosition = (transform.position - dif);
			newAnchorPosition = transform.InverseTransformPoint( newAnchorPosition);
			newAnchorPosition.z = 0;
			Anchor.localPosition = newAnchorPosition;

			YAccelleration =  ( OldLocalAnchorPosition.z - Anchor.localPosition.z ) ;

			OldLocalAnchorPosition = Anchor.localPosition;

			Debug.Log(YAccelleration);
			Debug.DrawLine (Anchor.position, pos, Color.red);
			Debug.DrawRay (transform.position, dif, Color.cyan);
			Debug.DrawRay( transform.position, zOffset * 20, Color.yellow);
		}
	}


	public float HandDistance;


	float YAccelleration;

	void LateUpdate(){
		SetAnchor ();
	}
}
