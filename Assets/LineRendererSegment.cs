using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LineRendererSegment{
	Vector3[] positions;
	public GameObject Source;
	public GameObject Target;
	float lastUpdateTime;
	float segmentLength;
	float randomOffset;
	float frequency;


	void UpdateUVLength(float length){

	}
	public LineRendererSegment(GameObject source, GameObject target, float subsegmentlength, float _randomoffset, float _frequency){
		Source = source;
		Target = target;
		segmentLength = subsegmentlength;
		randomOffset = _randomoffset;
		frequency = _frequency;

	}

	public void UpdateSegment(List<Vector3> previousPoints, bool isFirst ){
		
		float totalDistance = ( Source.transform.position - Target.transform.position).magnitude;
		int numOfPoints = (int) ( totalDistance / segmentLength) + 2;
		
		bool regenerate = false;
		
		if(positions == null || positions.Length != numOfPoints){
			positions = new Vector3[numOfPoints];
			regenerate = true;
		}
		
		
		positions[0] = Source.transform.position;
		positions[ positions.Length-1] = Target.transform.position;
		
		if( numOfPoints > 2 &&  (regenerate ||   lastUpdateTime + frequency < Time.time ) ){
			lastUpdateTime = Time.time;
			float steps = (float) 1 / (numOfPoints-1);
			for(int i = 1; i < positions.Length-1; i++){
				positions [i] = Vector3.Lerp( Source.transform.position, Target.transform.position, i * steps ) + Random.insideUnitSphere * randomOffset;
			}
		}
		
		for( int i = isFirst ? 0 : 1 ; i < positions.Length; i++){
			previousPoints.Add(positions[i]);
		}

		Debug.Log( previousPoints.Count);
	}
}