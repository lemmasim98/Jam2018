using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
	//importante:
	//inserire tutti gli oggetti di tipo terreno nel layer "ground"
	//settare groundLayer = "ground"
	//settare height ad almeno 100 o non si nota neanche
	public LayerMask groundLayer;
	public float height;

	bool IsGrounded() {
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);
		if (hit.collider != null) {
			return true;
		}
		return false;
	}

	private Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && IsGrounded()){
			rigidBody.AddForce (Vector2.up * height);
		}
	}
}
