using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Transform Pivot;

	public Color ActiveColor;
	public Renderer mMesh;

	HandModel mHand;

	Color StartColor;

	void Start(){
		StartColor = mMesh.renderer.material.color;
		PortalManager.Instance.RegisterPortal(this); 
	}

	public void Deactivate(){
		mMesh.material.color = StartColor;
	}

	public void Activate(){	
		mMesh.material.color = ActiveColor;
	}

	public void SetHand( HandModel h){

		mHand = h;
		StartPosition = mHand.GetWristPosition();
		UpdatePivot();
		//Debug.Break();
	}
	Vector3 StartPosition;

	void FixedUpdate(){
		if(mHand != null) UpdatePivot();
	}
	void UpdatePivot(){
		Vector3 HandDelta = mHand.GetWristPosition() - transform.position;
		HandDelta = mHand.GetWristPosition() - JamLeapController.Instance.GetHandReferencePoint( mHand).transform.position;

		Debug.DrawLine( mHand.GetWristPosition(), Vector3.zero);
//		Debug.Log( HandDelta.magnitude );
		Debug.DrawRay( transform.position, HandDelta, Color.red);

		Pivot.transform.position = transform.position - HandDelta * JamLeapController.Instance.MovementModifier - transform.up * 1 ;
	}
}
