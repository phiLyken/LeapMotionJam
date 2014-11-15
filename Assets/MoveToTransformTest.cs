using UnityEngine;
using System.Collections;

public class MoveToTransformTest : MonoBehaviour {

	public Transform TestObject;
	public AnimationCurve Curve;

	void Start(){
		StartCoroutine( MoveToTransform.SmoothTransitionToTransform( this.transform, TestObject.transform, 2, MoveToTransform.UpdateTime.update, Curve));
	}


}
