using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineRenderConnector : MonoBehaviour {

	public GameObject[] Points;

	public List<LineRendererSegment> Segments;
	List <Vector3> Positions;

	public float SubSegmentLength;
	public float RandomOffset;
	public float Frequency;

	LineRenderer m_lineRenderer;

	void Awake(){
		m_lineRenderer = GetComponent<LineRenderer>();
		Segments = new List<LineRendererSegment>();
		GameObject start = Points[0];

		for(int i = 1; i < Points.Length; i++){
			Segments.Add( new LineRendererSegment( start, Points[i], SubSegmentLength, RandomOffset, Frequency));
			start = Points[i];
		}
	}
	void SetUVLength(float length){
		GetComponent<RandomFlipBoard>().LengthModifier = length * 0.5f;
	}
	void OnDrawGizmos(){
		if( Points.Length > 0)
			foreach( GameObject p in Points) Gizmos.DrawWireSphere( p.transform.position, 0.5f);
	}
	void Update(){
		UpdateSegments();
		SetPoints(Positions);
	}

	void UpdateSegments(){
	
		Positions = new List<Vector3>();

		for(int i = 0; i < Segments.Count; i++){
			Segments[i].UpdateSegment( Positions, i == 0 );
		}
		SetUVLength( ( Positions[0] - Positions[ Positions.Count-1] ).magnitude  );
	}
	void SetPoints(List<Vector3> positions){
		
		m_lineRenderer.SetVertexCount(positions.Count);
		
		for(int i = 0; i < Positions.Count; i++){
			m_lineRenderer.SetPosition(i, Positions[i]);
		}
	}


}
