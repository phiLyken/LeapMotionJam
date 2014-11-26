using UnityEngine;
using System.Collections;

public class EnableChildOnDestroy : MonoBehaviour {

	public GameObject Target;

	void OnDestroy(){
		Target.SetActive(true);
		Target.transform.parent = null;
	}
}
