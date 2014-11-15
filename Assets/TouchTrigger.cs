using UnityEngine;
using System.Collections;

public class TouchTrigger : MonoBehaviour {

	public bool TriggerOnlyOnce;
	public TriggerBase TargetTrigger;

	bool triggered;

	void OnTriggerEnter( Collider col){
		if(TriggerOnlyOnce && triggered) return;

		TargetTrigger.trigger();

		triggered = true;

	}	                             
	
}
