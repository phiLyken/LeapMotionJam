using UnityEngine;
using System.Collections;

public class JamLeapController : MonoBehaviour {

	public GameObject FingerPointTargetObjectPrefab;
	public LayerMask HitLayers;
	public static JamLeapController Instance;
	public GameObject RightHandAnchor {
		get {
			return GameObject.FindGameObjectWithTag("Fuckers");
		}
	}
	GameObject FingerTarget;

	public Transform GetHandReferencePoint(HandModel hand){
		return (hand.GetLeapHand().IsRight   /* && JamLeapController.Instance.IsPointing */  ) ?  JamLeapController.Instance.RightHandAnchor.transform : hand.GetController().transform;
	}
	public Transform GetHandReferencePoint(FingerModel finger){
		return finger.GetLeapHand().IsRight ? JamLeapController.Instance.RightHandAnchor.transform : finger.GetController().transform;
	}
	void Awake(){
		Instance = this;
	}
	bool IsPhysicsHand(HandModel h){
		HandModel[] physHands = HandController.Instance.GetAllPhysicsHands();
		for(int i = 0; i < physHands.Length; i++){
			if(physHands[i] == h) return true;
		}

		return false;
	}

	bool HasRightHand(){
		HandModel[] physHands = HandController.Instance.GetAllPhysicsHands();
		for(int i = 0; i < physHands.Length; i++){
			if(physHands[i].GetLeapHand().IsRight) return true;
		}
		
		return false;
	}
	void Start(){
		HandController.Instance.OnCreateHand += OnCreateHand;

	}

	Vector3 CurrentFingerCastPosition;

	LeapFingerRayCaster FingerCaster;
	public bool IsPointing{
		get {
			return FingerCaster != null;
		}
	}
	public void OnCreateHand(HandModel hand){

		if( /* HandController.Instance.GetAllPhysicsHands().Length == 1 */ hand.GetLeapHand().IsLeft && IsPhysicsHand(hand)){
			
			Debug.Log("Created FIRST physics hand");
			Debug.Log( GetIndexFingerTip(hand).name);
			FingerCaster = GetIndexFingerTip(hand).gameObject.AddComponent<LeapFingerRayCaster>();
			FingerCaster.Init( hand, HitLayers);
		}
	} 

	void Update(){
		if( FingerCaster != null){
			UpdateFingerCastPosition();
			UpdateFingerTargetObject();
		}
	}
	void UpdateFingerTargetObject(){
		if( FingerTarget == null){
			FingerTarget = Instantiate ( FingerPointTargetObjectPrefab) as GameObject;
		}

		FingerTarget.transform.position = CurrentFingerCastPosition;
		FingerTarget.transform.rotation = Quaternion.LookRotation( FingerCaster.FingerCastNormal );
	}

	void UpdateFingerCastPosition(){

		if( FingerCaster != null ){
			CurrentFingerCastPosition = Vector3.Lerp( CurrentFingerCastPosition, FingerCaster.FingerCastPosition, FingerCaster.Confidence * Time.deltaTime * 20 );
		//	Debug.Log(FingerCaster.Confidence);
		} 
	}
	Transform GetIndexFingerTip(HandModel hand){

		//Get Index Finger
		RigidFinger Finger = hand.fingers[1] as RigidFinger;
		if(Finger == null){
			Debug.LogWarning("Finger does not have Bones");
			return null;

		}
		//last Bone is the tip
		return Finger.bones[3].transform;
	}
}
