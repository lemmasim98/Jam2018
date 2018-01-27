using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public Rigidbody rb;
	public int height;
	public LayerMask groundLayer;
	public bool doubleJump;

	bool IsGrounded() {
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);
		if (hit.collider != null) {
			return true;
			doubleJump = true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		bool doubleJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (IsGrounded ()) {
				rb.AddForce (Vector2.up * height);
			}
			if (doubleJump) {
				doubleJump = false;
				rb.AddForce (Vector2.up * height);
			}
		}
	}
}
