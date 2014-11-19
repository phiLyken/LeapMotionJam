using UnityEngine;
using System.Collections;

public class RandomFlipBoard : MonoBehaviour {

	public int Columns;
	public int Rows;
	public float LengthModifier;
	public float Frequency;
	public float RandomFrequency;


	void Start(){
		StartCoroutine(Flip ());
	}
	IEnumerator Flip(){
		float size =  (float) 1 / Rows;
		while(true){
			Vector2 _offset = new Vector2( 0, Random.Range(0, Rows) * size);
			Vector2 _tiling = new Vector2( LengthModifier, size);
			renderer.material.SetTextureOffset("_MainTex",_offset);
			renderer.material.SetTextureScale("_MainTex",_tiling);
			yield return new WaitForSeconds(Frequency + Random.value * RandomFrequency );
		}
	}
}
