using UnityEngine;
using System.Collections;

public class JamLeapController : MonoBehaviour {

	public GameObject FingerPointTargetObjectPrefab;
	public LayerMask HitLayers;
	public Vector3 RightHandCreatePosition;
	public static JamLeapController Instance;

	public float MovementModifier;
	public GameObject RightHandAnchor {
		get {
			return PortalManager.Instance.GetActivePortal().Pivot.gameObject;
		}
	}

	GameObject FingerTarget;
    Vector3 currentVelocityPos;
    Vector3 currentVelocityNormal;

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


	public Vector3 CurrentFingerCastPosition;
	public Vector3 CurrentFingerCastNormal;

	LeapFingerRayCaster FingerCaster;
	public bool IsPointing{
		get {
			return FingerCaster != null;
		}
	}
	public void OnCreateHand(HandModel hand){

		if(  hand.GetLeapHand().IsLeft && IsPhysicsHand(hand)){
			
	
			AddCaster (hand);

		} else if ( hand.GetLeapHand().IsRight){
			if(IsPhysicsHand(hand))
				AddParticlesToHand(hand);

			SetLayerRecursively(hand.gameObject, 9);
			PortalManager.Instance.GetActivePortal().SetHand(hand);
		}
	} 

	void Update(){
		if( FingerCaster != null){
			UpdateFingerCastPosition();
			UpdateFingerTargetObject();
		}
	}

	void AddCaster (HandModel hand)
	{
		FingerCaster = GetIndexFingerTip (hand).gameObject.AddComponent<LeapFingerRayCaster> ();
		FingerCaster.Init (hand, HitLayers);
	}

	void AddParticlesToHand(HandModel hand){
		foreach (BoxCollider col in hand.GetComponentsInChildren<BoxCollider>()){
			GameObject particleGo = Instantiate( Resources.Load("HandParticles"), col.transform.position, col.transform.rotation) as GameObject;
			particleGo.transform.parent = col.transform;
			Debug.Log("asdsad");
		}
	}
	void UpdateFingerTargetObject(){
		if( FingerTarget == null){
			FingerTarget = Instantiate ( FingerPointTargetObjectPrefab) as GameObject;
		}

		FingerTarget.transform.position = CurrentFingerCastPosition;
        FingerTarget.transform.rotation = Quaternion.LookRotation(CurrentFingerCastNormal);
	}

	void UpdateFingerCastPosition(){

		if( FingerCaster != null ){
            CurrentFingerCastPosition = Vector3.SmoothDamp(CurrentFingerCastPosition, FingerCaster.FingerCastPosition, ref currentVelocityPos, 0.2f);
            CurrentFingerCastNormal = Vector3.SmoothDamp(CurrentFingerCastNormal, FingerCaster.FingerCastNormal, ref currentVelocityNormal, 0.2f); 

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

	void SetLayerRecursively(GameObject obj, int newLayer  )
	{
		obj.layer = newLayer;
		
		foreach( Transform child in obj.transform )
		{
			SetLayerRecursively( child.gameObject, newLayer );
		}
	}
}
