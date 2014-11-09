using UnityEngine;
using System.Collections;

public class HandAnchor : MonoBehaviour {

	static HandAnchor _instance;
	public static Transform Anchor {
		get {
			return _instance.transform;
		}
	}
	void Awake(){
		_instance = this;
	}
}
