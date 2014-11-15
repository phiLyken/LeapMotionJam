using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public Transform Pivot;

	public Color ActiveColor;
	public Renderer mMesh;

	Color StartColor;

	void Start(){
		StartColor = mMesh.renderer.material.color;
		PortalManager.Instance.RegisterPortal(this);
	}

	public void Deactivate(){
		mMesh.material.color = StartColor;
	}

	public void Activate(){
		mMesh.material.color = ActiveColor;
	}
}
