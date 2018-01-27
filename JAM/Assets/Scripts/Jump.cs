using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public Rigidbody2D rb;
	public int height;
	public LayerMask groundLayer;
	public bool doubleJump;

	bool IsGrounded() {
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 0.7f;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);
		if (hit.collider != null) {
			Debug.Log("cazzo");
			doubleJump = true;
			return true;
			//doubleJump = true;
		}
		return false;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		bool doubleJump = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			if (IsGrounded ()) {
				rb.AddForce (Vector2.up * height);
			}
			else if (doubleJump) {
				doubleJump = false;
				rb.AddForce (Vector2.up * height);
			}
		}
	}
}
