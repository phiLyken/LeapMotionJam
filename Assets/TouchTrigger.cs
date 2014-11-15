using UnityEngine;
using System.Collections;

public class TouchTrigger : MonoBehaviour {

	public bool TriggerOnlyOnce;
	public TriggerBase TargetTrigger;

	bool triggered;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawSphere(transform.position, transform.localScale.x * ((SphereCollider)collider).radius);
    }

	void OnTriggerEnter( Collider col){
		if(TriggerOnlyOnce && triggered) return;

		TargetTrigger.trigger();

		triggered = true;

	}	                             
	
}
