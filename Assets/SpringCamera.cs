using UnityEngine;
using System.Collections;

public class SpringCamera : MonoBehaviour {

	public Transform Target;
	public float CameraAdjustmentSpeed;

	public float Strength;

	Vector3 SmoothTarget;

	// Use this for initialization
	void Start () {
		Target.transform.position = transform.position + transform.forward * 10;
	}
	
	// Update is called once per frame
	void Update () {
		SmoothTarget = Vector3.Lerp( SmoothTarget, GetTargetPoint(), CameraAdjustmentSpeed * Time.deltaTime);
		transform.LookAt( SmoothTarget);

		Debug.DrawLine(transform.position, SmoothTarget, Color.red);
		Debug.DrawLine(transform.position, GetTargetPoint(), Color.blue);
	}



	Vector3 GetTargetPoint(){
		HandModel[] hands = HandController.Instance.GetAllPhysicsHands();

		Vector3 _v3pos = Target.transform.position;
//		Debug.Log( hands.Length );
		//When there are no hands in the scene, return the targetposition
		if( hands.Length == 0 || hands[0] == null ) return _v3pos;



		//When there are 2 hands, get the center of both
		if( hands.Length > 1 ){
			_v3pos = Vector3.Lerp( hands[0].GetPalmPosition(), hands[1].GetPalmPosition(), 0.5f);
		} else {
			_v3pos = hands[0].GetPalmPosition();
			Debug.DrawLine(transform.position, hands[0].GetPalmPosition(), Color.cyan);
		}

		//Interpolate between the "Targetposition" and the fixed Target-transform
		return Vector3.Lerp( Target.transform.position, _v3pos, Strength );
	}

		                                    
}
