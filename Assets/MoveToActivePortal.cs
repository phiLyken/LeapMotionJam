using UnityEngine;
using System.Collections;

public class MoveToActivePortal : MonoBehaviour {

	public void SwitchPortal(Portal p){
		transform.position = p.transform.position;
	}
	// Use this for initialization
	void Start () {
		SwitchPortal( PortalManager.Instance.GetActivePortal() );
		PortalManager.Instance.OnPortalActivation += SwitchPortal;
	}

	void OnDestroy(){
		PortalManager.Instance.OnPortalActivation -= SwitchPortal;
	}

}
