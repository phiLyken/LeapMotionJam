using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalManager : MonoBehaviour {

	public static PortalManager Instance;

	public float ActivateRange;
	public float DeactivateRange;

	public List<GameObject> Portals = new List<GameObject>();
	Portal ActivePortal;

	void Awake(){
		Instance = this;

	}

	public bool IsPortalActive(){
		return ActivePortal != null;
	}

	public Portal GetActivePortal(){
		return ActivePortal;
	}

	public void ActivatePortat(Portal p){
		DeactivateCurrentPortal();
		ActivePortal = p;
		ActivePortal.Activate();
	}

	void DeactivateCurrentPortal(){
		if(ActivePortal == null) return;

		ActivePortal.Deactivate();
		ActivePortal = null;
	}
	public Transform GetRightHandPivot(){
		return ActivePortal.transform;
	}

	void Update(){

		if( JamLeapController.Instance.IsPointing){
			SearchForPortals();
		}
	}

	public void RegisterPortal(Portal p){
		Portals.Add(p.gameObject);
	}

	void SearchForPortals(){

		Vector3 SearchPosition =  JamLeapController.Instance.CurrentFingerCastPosition;

		if ( ActivePortal != null && (SearchPosition - ActivePortal.transform.position).magnitude < DeactivateRange){
			//DeactivateCurrentPortal();
		}

	

		float _distance = 0;
		GameObject closest = GetClosestGameObject( SearchPosition, Portals, ref _distance);
		if(closest != null){
			Debug.DrawLine(closest.transform.position, SearchPosition, Color.yellow);
		}

		if(closest != null && _distance < ActivateRange){
			ActivatePortat( closest.GetComponent<Portal>());
	   	}


	}
	   


	public GameObject GetClosestGameObject(Vector3 originPosition, List<GameObject> objects, ref float distance){

		if( objects.Count == 0) return null;
		
		GameObject best = objects[0];
		
		float closestDistance = Vector3.Magnitude( best.transform.position - originPosition);
		
		for(int i = 1 ; i < objects.Count; i++){
			float currentDistance = Vector3.Magnitude( objects[i].transform.position - originPosition);
			if(currentDistance < closestDistance){
				best = objects[i];
				closestDistance = currentDistance;
			}
		}
		distance = closestDistance;
		return best;
	}
}
