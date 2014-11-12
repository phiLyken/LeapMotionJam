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
		return JamLeapController.Instance.IsPointing ? Vector3.Lerp( JamLeapController.Instance.CurrentFingerCastPosition, Target.position, Strength) : Target.position;
	}

		                                    
}
