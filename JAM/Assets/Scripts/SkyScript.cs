using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour {
	public GameObject padrone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-0.0005f, 0, 0);
		//transform.position = new Vector3(transform.position.x, 0, 0);
		
	}
}
