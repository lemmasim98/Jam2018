using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour {

	public LayerMask mask_audio;
	string AudioID;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 14, true);
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hitAudio = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, mask_audio);
		if (hitAudio.collider != null) {
			Debug.Log ("audio");
			AudioID = hitAudio.collider.tag;
			Debug.Log(AudioID);
		}
	}
}
