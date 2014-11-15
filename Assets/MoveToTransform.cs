using UnityEngine;
using System.Collections;

public class MoveToTransform : MonoBehaviour {

	public enum UpdateTime {
		update, lateUpdate, fixedUpdate
	}

	public static IEnumerator SmoothTransitionToTransform( Transform from, Transform to, float time, UpdateTime whentoUpdate, AnimationCurve curve){

		float startTime = Time.time;
		Vector3 startPos = from.position;
		Quaternion startRotation = from.rotation;


		while( startTime + time > Time.time){

			float p = ( Time.time - startTime) / time;
		
			if( curve != null){
				p = curve.Evaluate(p);
			}

			from.position = Vector3.Lerp(startPos, to.transform.position, p);	            
			from.rotation = Quaternion.Slerp( startRotation, to.rotation, p);

			switch (whentoUpdate) {

				case UpdateTime.fixedUpdate:
					yield return new WaitForFixedUpdate();
					break;
				case UpdateTime.lateUpdate:
					yield return new WaitForEndOfFrame();
					break;
				case UpdateTime.update:
					yield return null;
					break; 		
			}


		}
		yield break;
	}



}
