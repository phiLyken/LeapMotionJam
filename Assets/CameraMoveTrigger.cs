using UnityEngine;
using System.Collections;

public class CameraMoveTrigger : TriggerBase {

	public AnimationCurve Curve;
	public float MoveTime;

	public override void trigger ()
	{
		StartCoroutine(MoveToTransform.SmoothTransitionToTransform( GameObject.FindGameObjectWithTag("Player").transform, this.transform,MoveTime, MoveToTransform.UpdateTime.update, Curve));
	}

}
