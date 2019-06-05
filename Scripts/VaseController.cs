using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseController : MonoBehaviour {

	private static int numberVase;
	public GameObject DestroyedObject;
	public GameObject ObjectInVase;
	public AudioSource source;
	public AudioClip Clip_Vase_Broken;
	public SoundExternMonster vaseSound;
	public int numberVaseTotal = 2;

	void Start() {
		if (numberVase >= numberVaseTotal)    
			numberVase = 0;
		numberVase++;
		Debug.Log (numberVase);
	}

	void OnCollisionEnter( Collision collision ) {
		if(collision.gameObject.layer == LayerMask.NameToLayer("Terrain")) {
			float hitVol = collision.relativeVelocity.magnitude * AudioListener.volume;
			source.PlayOneShot (Clip_Vase_Broken, hitVol);
			vaseSound.PlaySound ();
			DestroyIt();
		}
	}

	void DestroyIt(){
		numberVase--;
		Instantiate (DestroyedObject, transform.position, transform.rotation);
		if (numberVase == 0) {
			ObjectInVase.SetActive (true);
		}
		Destroy(gameObject);
	}
}
