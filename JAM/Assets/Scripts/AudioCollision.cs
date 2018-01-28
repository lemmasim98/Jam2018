using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour {
	public AudioClip tutorial2;
	public AudioClip tutorial3;
	public AudioClip tutorial5;
	public AudioClip warning1;
	public AudioClip risposta1;
	public AudioClip macchine;
	public AudioClip cartello;
	public LayerMask mask_audio;
	string AudioID;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 14, true);
		aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hitAudio = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, mask_audio);
		if (hitAudio.collider != null) {
			Debug.Log ("audio");

			AudioID = hitAudio.collider.tag;
			Debug.Log(AudioID);
			switch(AudioID){
				case "Tutorial 2":
			aud.clip = tutorial2;
			break;
				case "Tutorial 3":
			aud.clip = tutorial3;
			break;
				case "Tutorial 5":
			aud.clip = tutorial5;
			break;				
				case "warning1":
			aud.clip = warning1;
			break;
				case "Risposta1":
			aud.clip = risposta1;
			break;
			case "Macchine":
			aud.clip = macchine;
			break;
			case "Cartello":
			aud.clip = cartello;
			break;
			}
        aud.Play();
		}
	}
}
