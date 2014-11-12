using UnityEngine;
using System.Collections;

public class EnableOnTrigger : TriggerBase {

	public GameObject Target;

	public override void trigger(){
		Target.SetActive(true);
	}

}
