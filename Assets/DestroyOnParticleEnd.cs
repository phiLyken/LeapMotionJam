using UnityEngine;
using System.Collections;

public class DestroyOnParticleEnd : MonoBehaviour {


	void OnEnable(){
		StartCoroutine(WaitUntilPlayed( GetComponent<ParticleSystem>()));
	}
	IEnumerator WaitUntilPlayed(ParticleSystem particles){

		yield return new WaitForSeconds(0.1f);

		while( particles.particleCount > 0 ){
			yield return null;
		}

		Destroy(this.gameObject);
	}
}
